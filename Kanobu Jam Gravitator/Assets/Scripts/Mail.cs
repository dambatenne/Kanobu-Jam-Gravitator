using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
 
 public class Mail : MonoBehaviour {

 	[SerializeField] private GameObject addressInput;
 	[SerializeField] private GameObject mainCamera;

 	public void MailRequestFrom () {

		String fromAddress = addressInput.GetComponent <Text> ().text;

		MailMessage mail = new MailMessage();

		mail.From = new MailAddress(fromAddress);
		mail.To.Add("denis.ambatenne@mathycle.com");
		mail.Subject = "New levels request";
		mail.Body = fromAddress + " requsted new levels!";

		SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
		smtpServer.Port = 587;
		smtpServer.Credentials = new System.Net.NetworkCredential("gravitator.game@gmail.com", "FbopF4515!") as ICredentialsByHost;
		smtpServer.EnableSsl = true;

		ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
			return true; 
		};

		smtpServer.Send(mail);
		Debug.Log("success");


     }

	public void MailDenialFrom () {

		String fromAddress = addressInput.GetComponent <Text> ().text;

		MailMessage mail = new MailMessage();

		mail.From = new MailAddress(fromAddress);
		mail.To.Add("denis.ambatenne@mathycle.com");
		mail.Subject = "New levels denial";
		mail.Body = fromAddress + " denied new levels!";

		SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
		smtpServer.Port = 587;
		smtpServer.Credentials = new System.Net.NetworkCredential("gravitator.game@gmail.com", "FbopF4515!") as ICredentialsByHost;
		smtpServer.EnableSsl = true;

		ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
			return true; 
		};

		smtpServer.Send(mail);
		Debug.Log("success");

		mainCamera.GetComponent <GameManagerHelper> ().LoadMainMenu ();

    }

    public void SendRequest (bool yes) {

		string fromAddress = addressInput.GetComponent <Text> ().text;

    	if (yes) {

			WebGLSendMail ("gravitator.game@gmail.com", (string.IsNullOrEmpty(fromAddress) ? "empty@empty.no" : fromAddress), "New levels: YES", "Request for new levels!");

    	} else if (!yes) {

			WebGLSendMail ("gravitator.game@gmail.com", (string.IsNullOrEmpty(fromAddress) ? "empty@empty.no" : fromAddress), "New levels: NO", "Denial of new levels!");

    	} else {

    		Debug.Log ("Some error in sending mail");

    	}

    }

	private void WebGLSendMail (string toEmail, string fromEmail, string subject, string body) {

		string url = "https://sendgrid.com/api/mail.send.json?";
		string xsmtpapiJSON = "{\"category\":\"game_email\"}";
		string api_key = "FbopF4515!";
		string api_user = "dambatenne";
		  
		url += "to=" + toEmail;
		url += "&from=" + fromEmail;
		  
		//you have to change every instance of space to %20 or you'll get a 400 error
		string subjectWithoutSpace = subject.Replace(" ", "%20");
		url += "&subject=" + subjectWithoutSpace;
		string bodyWithoutSpace = body.Replace(" ", "%20");
		  
		  url += "&text=" + bodyWithoutSpace;
		  url += "&x-smtpapi=" + xsmtpapiJSON;
		  url += "&api_user=" + api_user;
		  url += "&api_key=" + api_key;

		  Debug.Log (url);

		  WWW www = new WWW(url);
		  StartCoroutine(WaitForRequest(www));
	}

	IEnumerator WaitForRequest (WWW www) {
		  yield return www;

		  // check for errors
		  if (www.error == null)
		  {
		      Debug.Log("WWW Ok! Email sent through Web API: " + www.text);
		  } else {
		      Debug.Log("WWW Error: "+ www.error);
		  }	
		  mainCamera.GetComponent <GameManagerHelper> ().LoadMainMenu ();
    
	}
}