using System;
using System.Collections.Generic;
using System.Text;

namespace S3_MVVM.ViewModels
{
    public interface IViewModelBase<TEntity>
    {
        void LoadAll();
        void Initialize();
    }
}
