using SendGrid.Helpers.Mail;

namespace TimeCapsule.Model
{
    public static class Constants
    {
        public const string SecretKey = "oPiRVrmHckeX/KOUi2DBfM8SBPiIfLnQ+fcTIEUm";
        public const string IdAccessKey = "AKIAXTH33M3DS7GRGE35";
        public const string BucketName = "timecapsuleemails";
        
        public const string SendGridApiKey = "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";
        private const string FromEmailAddress = "cartaparaofuturo@igrejaCapital.org.br";
        private const string FromEmailName = "Capsula do Tempo";
        private const string EmailAddressResponse = "comunicacao@igrejaCapital.org.br";
        public static EmailAddress FromEmail => new EmailAddress(FromEmailAddress, FromEmailName);
        public static EmailAddress ResponseEmailAddress  => new EmailAddress(EmailAddressResponse);

        public const string SubjectFromThePast = "Your letter from the past";
        
    }
}