﻿using AspNetSandbox.Models;
using System.Collections.Generic;

namespace AspNetSandbox
{
    public interface IBooksSRepository
    {
        void Delete(int id);

        IEnumerable<Book> Get();

        Book Get(int id);

        void Post(Book value);

        void Put(int id, Book value);
    }
}