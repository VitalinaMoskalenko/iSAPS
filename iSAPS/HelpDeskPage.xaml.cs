using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Messaging;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iSAPS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpDeskPage : ContentPage
    {
        public HelpDeskPage()
        {
            InitializeComponent();
            LblDelegate();
        }
        public void LblDelegate()
        {
            lblCallDeanFirst.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    CallDean(1);
                })
            });
            lblCallDeanSekond.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    CallDean(2);
                })
            });
            lblCallRecrutation.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    CallDean(3);
                })
            });
        }
        public void CallDean(int number) 
        {
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall)
            {
                switch (number)
                {
                    case 1:
                        phoneDialer.MakePhoneCall("+48525670045");
                        break;
                    case 2:
                        phoneDialer.MakePhoneCall("+48525670777");
                        break;
                    case 3:
                        phoneDialer.MakePhoneCall("+48525670000");
                        break;
                    default:
                        break;
                }

            }

        }
    }
}