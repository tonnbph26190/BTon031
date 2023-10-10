﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.IRepositories
{
    public interface IAllRepositories<TEntity> where TEntity : class
    {
        DbSet<TEntity> Entities { get; set; } // DBset tổng
        // Các phương thức Lấy dữ liệu
        Task<TEntity> GetByIdAsync(string id); // Lấy 1
        Task<IEnumerable<TEntity>> GetAllAsync(); // Lấy tất
        // Các phương thức thêm
        Task<TEntity> AddOneAsync(TEntity entity); // thêm 1
        Task<TEntity> AddManyAsync(IEnumerable<TEntity> entity); // thêm một loạt
        // Các phương thức xóa
        Task<TEntity> DeleteOneAsync(TEntity entity);  // Xóa 1
        Task<TEntity> DeleteManyAsync(IEnumerable<TEntity> entity); // Xóa 1 loạt
        // Các phương thức sửa
        Task<TEntity> UpdateOneAsync(TEntity entity); // Sửa 1
        Task<IEnumerable<TEntity>> UpdateManyAsync(IEnumerable<TEntity> entity); // Sửa 1 loạt
        Task UpdateQuantity(TEntity entity, int newQuantity);
    }
}
