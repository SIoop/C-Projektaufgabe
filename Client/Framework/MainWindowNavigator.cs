using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using Client.Views;
using Models;

namespace Client.Framework
{
    public static class MainWindowNavigator
    {
        public static Page CurrentNavStatus { get; set; }

        public delegate void SetButtonStatus(bool a, bool b, bool c, bool d, bool e);

        public static SetButtonStatus ButtonMethod { get; set; }

        public static Frame NavFrame;
        public static List<IPageControllerBase> UserPageControllers { get; set; } = new List<IPageControllerBase>();

        public static List<IPageControllerBase> AdminPageControllers { get; set; } = new List<IPageControllerBase>();

        public static ObservableCollection<Page> UserPages = new ObservableCollection<Page>();
        public static Page StartPage;
        public static ObservableCollection<Page> AdminPages;

        public static (ObservableCollection<Page>, ObservableCollection<Page>) InitializePages()
        {
            UserPageControllers[0].Initialize();
            UserPageControllers[0].ButtonHandler += ButtonMethod;
            UserPages.Add(UserPageControllers[0].Page);
            StartPage = UserPages[0];

            AdminPages = new ObservableCollection<Page>(AdminPageControllers.Select(c =>
            {
                c.Initialize();
                c.ButtonHandler += ButtonMethod;
                return c.Page;
            }).ToList());

            return (UserPages, AdminPages);
        }

        public static void NavigateTo(string page)
        {
            var userPage = UserPages.ToList().Find(p => p.Title == page);
            var adminPage = AdminPages.ToList().Find(p => p.Title == page);


            var foundPage = userPage ?? adminPage;

            NavFrame.Navigate(foundPage);
            var controller = UserPageControllers.Find(c =>
                                 Equals(c.Page, UserPages.ToList().Find(p => p.Title == foundPage.Title))) ??
                             AdminPageControllers.Find(c =>
                                 Equals(c.Page, AdminPages.ToList().Find(p => p.Title == foundPage.Title)));
            ButtonMethod.Invoke(controller.NewButtonActive, controller.EditButtonActive, controller.SaveButtonActive, controller.DeleteButtonActive, false);

            CurrentNavStatus = foundPage;
            OnNavigationAlert(CurrentNavStatus.Title);
        }

        public static void NavigateToFirstPage()
        {
            NavFrame.Navigate(UserPages[0]);

            CurrentNavStatus = UserPages[0];
            OnNavigationAlert(CurrentNavStatus.Title);
        }

        private static void OnNavigationAlert(string target)
        {
            UserPageControllers.ForEach(c =>
            {
                if (c.Page != null)
                {
                    c.OnNavigation(target);
                }
            });
            AdminPageControllers.ForEach(c =>
            {
                if (c.Page != null)
                {
                    c.OnNavigation(target);
                }
            });
        } 

        public static void EnableAllUserPages()
        {
            UserPageControllers.GetRange(1, UserPageControllers.Count - 1).ForEach(c =>
            {
                c.Initialize();
                c.ButtonHandler += ButtonMethod;
                UserPages.Add(c.Page);
            });
        }

        public static void OnNew(object obj)
        {
            var userController = UserPageControllers.Find(c => c.Page == CurrentNavStatus);
            var adminController = AdminPageControllers.Find(c => c.Page == CurrentNavStatus);
            var foundController = userController ?? adminController;
            foundController.NewButtonPressed();
        }

        public static void OnEdit(object obj)
        {
            var userController = UserPageControllers.Find(c => c.Page == CurrentNavStatus);
            var adminController = AdminPageControllers.Find(c => c.Page == CurrentNavStatus);
            var foundController = userController ?? adminController;
            foundController.EditButtonPressed();
        }

        public static void OnSave(object obj)
        {
            var userController = UserPageControllers.Find(c => c.Page == CurrentNavStatus);
            var adminController = AdminPageControllers.Find(c => c.Page == CurrentNavStatus);
            var foundController = userController ?? adminController;
            foundController.SaveButtonPressed();
        }

        public static void OnDelete(object obj)
        {
            var userController = UserPageControllers.Find(c => c.Page == CurrentNavStatus);
            var adminController = AdminPageControllers.Find(c => c.Page == CurrentNavStatus);
            var foundController = userController ?? adminController;
            foundController.DeleteButtonPressed();
        }

        public static void OnButtonChange(bool a, bool b, bool c, bool d)
        {

        }
    }
}