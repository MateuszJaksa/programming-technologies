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
            SimpleIoc.Default.Register<AddEditCatalogViewModel>();
            SimpleIoc.Default.Register<AddEditStateViewModel>();
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

        public AddEditCatalogViewModel AddCatalogViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<AddEditCatalogViewModel>();
            }
        }

        public AddEditStateViewModel AddStateViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<AddEditStateViewModel>();
            }
        }
    }
}
