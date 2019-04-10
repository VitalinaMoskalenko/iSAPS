using System;
using iSAPS.iOS;
using Xamarin.Forms;
using UIKit;


[assembly: Dependency(typeof(Toast_iOS))]
namespace iSAPS.iOS
{
    public class Toast_iOS : Toast
    {
        public void Show(string message)
        {
            //Create Alert
            var okAlertController = UIAlertController.Create("Title", "The message", UIAlertControllerStyle.Alert);

            //Add Action
            okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));


        }
    }
}

