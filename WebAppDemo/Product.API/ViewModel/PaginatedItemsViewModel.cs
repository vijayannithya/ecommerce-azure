using System.Collections.Generic;
namespace ProductAPI.ViewModel { 

    public class PaginatedItemsViewModel<TEntity> where TEntity : class
    {
        //public int PageIndex { get; private set; }

        //public int PageSize { get; private set; }

        //public long Count { get; private set; }

        public IEnumerable<TEntity> Data { get; private set; }

        public PaginatedItemsViewModel(IEnumerable<TEntity> data)
        {
            //this.PageIndex = 1;
            //this.PageSize = 1;
            //this.Count = 1;
            this.Data = data;
        }
    }
}
