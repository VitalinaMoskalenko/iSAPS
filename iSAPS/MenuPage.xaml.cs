using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iSAPS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : MasterDetailPage
    {
        public List<BoxView> boxViews = new List<BoxView>();
        public List<Image> images = new List<Image>();
        public List<string> imgBlue = new List<string>();
        public List<Label> labels = new List<Label>();
        public MenuPage()
        {
            InitializeComponent();
            labels = new List<Label> { lblClassSchedule, lblFinance, lblHelpDesk, lblNews, lblProffesor, lblSession, lblProffile };
            boxViews = new List<BoxView> { bvFinance, bvSession, bvClassSchedule, bvNews, bvHelpDesk, bvProffesor, bvProffile };
            images = new List<Image> { imgClassSchedule, imgHelpDesk, imgNews, imgFinance, imgProffesor, imgSession, imgProffile };
            imgBlue = new List<string> { "calendar_1.png", "help_1.png", "home_1.png", "money_1.png", "proffesor_1.png", "time_1.png", "avatar.png" };
            LblDelegate();
            BvDelegate();
            ImgDelegate();
        }

        public void ImgDelegate()
        {
            imgProffile.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    ProffileFunction();
                })
            });
            imgLogOut.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    LogOutFunction();
                })
            });
            imgFinance.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    FuncFinance();
                }
            )
            });
            imgSession.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    FuncSession();
                })
            });
            imgClassSchedule.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    FuncClassSchedule();
                })
            });
            imgHelpDesk.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    FuncHelpDesk();
                })
            });
            imgNews.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    FuncNews();
                })
            });
            imgProffesor.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    FuncProffesor();
                })
            });
        }
        public void BvDelegate()
        {
            bvProffile.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    ProffileFunction();
                })
            });
            bvFinance.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    FuncFinance();
                }
            )
            });
            bvSession.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    FuncSession();
                })
            });
            bvClassSchedule.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    FuncClassSchedule();
                })
            });
            bvHelpDesk.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    FuncHelpDesk();
                })
            });
            bvNews.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    FuncNews();
                })
            });
            bvProffesor.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    FuncProffesor();
                })
            });
        }
        public void LblDelegate()
        {
            lblProffile.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    ProffileFunction();
                })
            });
            lblFinance.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    FuncFinance();
                }
            )
            });
            lblSession.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    FuncSession();
                })
            });
            lblClassSchedule.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    FuncClassSchedule();
                })
            });
            lblHelpDesk.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    FuncHelpDesk();
                })
            });
            lblNews.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    FuncNews();
                })
            });
            lblProffesor.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    FuncProffesor();
                })
            });
        }
        public void ChangeColour(BoxView bv)
        {
            bv.Color = Color.FromHex("#2196f3");
        }
        public void AllWhite()
        {
            int i = 0;
            foreach (var bv in boxViews)
            {
                bv.Color = Color.FromHex("");
            }
            foreach (var img in images)
            {
                img.Source = imgBlue[i];
                i++;
            }
            foreach (var lbl in labels)
            {
                lbl.TextColor = Color.FromHex("#2196f3");
            }
        }
        public void FuncFinance()
        {
            Detail = new NavigationPage(new FinancePage());
            AllWhite();
            lblFinance.TextColor = Color.White;
            imgFinance.Source = "money_2.png";
            ChangeColour(bvFinance);
        }
        public void FuncSession()
        {
            Detail = new NavigationPage(new SessionPage());
            AllWhite();
            lblSession.TextColor = Color.White;
            imgSession.Source = "time_2.png";
            ChangeColour(bvSession);
        }
        public void FuncClassSchedule()
        {
            Detail = new NavigationPage(new ClassSchedulePage());
            AllWhite();
            lblClassSchedule.TextColor = Color.White;
            imgClassSchedule.Source = "calendar_2.png";
            ChangeColour(bvClassSchedule);
        }
        public void FuncHelpDesk()
        {
            Detail = new NavigationPage(new HelpDeskPage());
            AllWhite();
            lblHelpDesk.TextColor = Color.White;
            imgHelpDesk.Source = "help_2.png";
            ChangeColour(bvHelpDesk);
        }
        public void FuncNews()
        {
            Detail = new NavigationPage(new NewsPage());
            AllWhite();
            lblNews.TextColor = Color.White;
            imgNews.Source = "home_2.png";
            ChangeColour(bvNews);
        }
        public void FuncProffesor()
        {
            Detail = new NavigationPage(new ProffesorPage());
            AllWhite();
            lblProffesor.TextColor = Color.White;
            imgProffesor.Source = "proffesor_2.png";
            ChangeColour(bvProffesor);
        }
        public void LogOutFunction()
        {
            App.Current.MainPage = new MainPage();
        }
        public void ProffileFunction() 
        {
            Detail = new NavigationPage(new ProfilePage());
            AllWhite();
            lblProffile.TextColor = Color.White;
            imgProffile.Source = "avatar_2.png";
            ChangeColour(bvProffile);
        }
    }
}