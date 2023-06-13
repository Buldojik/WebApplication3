using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;

namespace WebApplication3.Controllers
{
    public interface IDivisionController<TDbModel>
    {
        public List<TDbModel> GetAll();
        public TDbModel Get(TDbModel model);
        public TDbModel Create(TDbModel model);
        public TDbModel Update(TDbModel model);
        public void Delete(TDbModel model);
    }
}
