using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity
{
    public class PaginatedList<T, K> : List<K>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        private readonly IMapper _mapper;

        public PaginatedList(IMapper mapper)
        {
            this._mapper = mapper;
        }

        public PaginatedList(List<K> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public static async Task<PaginatedList<T, K>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            var studentsToMap = Mapper.Map<List<T>, List<K>>(items.ToList());
            var newStudent = studentsToMap.AsQueryable();

            return new PaginatedList<T, K>(studentsToMap, count, pageIndex, pageSize);
        }
    }
}