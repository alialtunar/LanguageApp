using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Interfaces
{
    public interface ICategoryRepository: IGenericRepository<Category>
    {
        Task<Category> GetCategoryWithProducts(string id);

    }
}
