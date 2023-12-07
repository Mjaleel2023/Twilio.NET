using System;
using DotNetEnv;
using Twilio;
using Twilio.Rest.Verify.V2.Service;
using Twilio.Types;



namespace abc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Env.Load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
            string serviceSid = Environment.GetEnvironmentVariable("TWILIO_SERVICE_SID");

            TwilioClient.Init(accountSid, authToken, serviceSid);

            string phoneNumber = txtPhoneNumber.Text;


            var verification = VerificationResource.Create(
                to: phoneNumber,
                channel: "sms",
                pathServiceSid: serviceSid
            );

            MessageBox.Show("OTP Sent Successfully!");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
            string serviceSid = Environment.GetEnvironmentVariable("TWILIO_SERVICE_SID");

            TwilioClient.Init(accountSid, authToken, serviceSid);

            string otp=otpverify.Text;
            string phoneNumber = txtPhoneNumber.Text;
            
            var verificationCheck = VerificationCheckResource.Create(
            to: phoneNumber,
            code: otp,
            pathServiceSid: serviceSid
        );
            if (verificationCheck.Status == "approved")
            {
                MessageBox.Show("OTP Verified Successfully!");
            }
            else
            {
                MessageBox.Show("OTP Verification Failed. Please try again.");
            }
        }
    }
}
