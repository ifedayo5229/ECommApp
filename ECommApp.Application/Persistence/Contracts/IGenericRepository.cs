using ECommApp.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommApp.Application.Persistence.Contracts
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
		T GetById(int id);
		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		IEnumerable<T> GetAll();

	}
}
