using System.Collections.Generic;
using AspNetSandbox.Models;

namespace AspNetSandbox.Services
{
    public interface IBooksRepository
    {
        void Delete(int id);

        IEnumerable<Book> Get();

        Book Get(int id);

        void Post(Book value);

        void Put(int id, Book value);
    }
}