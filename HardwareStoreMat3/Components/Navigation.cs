using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HardwareStoreMat3.Components
{
    internal class Navigation
    {
        static List<PageComponent> compon = new List<PageComponent>();
        public static MainWindow mainWindow { get; set; }

        public static void ClearHistory()
        {
            compon.Clear();
        }
        public static void NextPage(PageComponent pageComponent)
        {
            compon.Add(pageComponent);
            Update(pageComponent);
        }
        public static void BackPage()
        {
            if (compon.Count > 1)
            {
                compon.RemoveAt(compon.Count - 1);
                Update(compon[compon.Count - 1]);
            }
        }
        private static void Update(PageComponent pageComponent)
        {
            //if(App.isAdmin == false)
            //{

            //}

        }
    }
    class PageComponent
    {
        public string Title;
        public Page Page;
        public PageComponent(string title, Page page)
        {
            Page = page;
            Title = title;
        }
    }
}
