using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Shijra
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //FirebaseApp app = FirebaseApp.Create(new AppOptions()
            //{
            //    Credential = GoogleCredential.FromFile("hashmi-shijra-firebase-adminsdk.json")
            //});

            //var auth = "5Z5RG8RqP4Y10SwLhhiGEHQqf2RR3Aq371csm5T4"; // your app secret
            //var firebaseClient = new FirebaseClient(
            //  "https://hashmi-shijra.firebaseio.com",
            //  new FirebaseOptions
            //  {
            //      AuthTokenAsyncFactory = () => Task.FromResult(auth)
            //  });

            
            Application.Run(new MainForm());
        }
    }

    public class ShijraContext
    {
        public static Shijra.Model.shijraEntities entities = new Model.shijraEntities();
    }

}
