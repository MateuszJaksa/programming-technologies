using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;


namespace Presentation.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<CatalogViewModel>();
            SimpleIoc.Default.Register<StateViewModel>();
            SimpleIoc.Default.Register<AddCatalogViewModel>();
            SimpleIoc.Default.Register<AddStateViewModel>();
        }

        public CatalogViewModel CatalogViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<CatalogViewModel>();
            }
        }

        public StateViewModel StateViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<StateViewModel>();
            }
        }

        public AddCatalogViewModel AddCatalogViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<AddCatalogViewModel>();
            }
        }

        public AddStateViewModel AddStateViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<AddStateViewModel>();
            }
        }
    }
}
