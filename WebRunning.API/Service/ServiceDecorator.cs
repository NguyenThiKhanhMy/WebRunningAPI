using WebRunning.Lib.Interfaces;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

namespace WebRunning.API.Service
{
    class ServiceDecorator<TEntity>
    {
        private IRepositoryBase<TEntity> _serviceBase;
        public ServiceDecorator(IServiceWrapper service)
        {
            #region add service
            if (typeof(TEntity) == typeof(Model.Sys_Category))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Sys_Category;
            }
            else if(typeof(TEntity) == typeof(Model.Sys_User))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Sys_User;
            }
            else if (typeof(TEntity) == typeof(Model.Sys_File))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Sys_File;
            }
            else if (typeof(TEntity) == typeof(Model.Sys_Organization))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Sys_Organization;
            }
            else if (typeof(TEntity) == typeof(Model.Sys_Role))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Sys_Role;
            }
            else if (typeof(TEntity) == typeof(Model.Sys_Config))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Sys_Config;
            }
            else if (typeof(TEntity) == typeof(Model.Sys_Permission))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Sys_Permission;
            }
            else if (typeof(TEntity) == typeof(Model.Sys_Resource))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Sys_Resource;
            }
            else if (typeof(TEntity) == typeof(Model.Sys_Notification))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Sys_Notification;
            }
            //THIếu ở dây
            else if (typeof(TEntity) == typeof(Model.Por_Menu))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Por_Menu;
            }
            else if (typeof(TEntity) == typeof(Model.Por_Anh))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Por_Anh;
            }
            else if (typeof(TEntity) == typeof(Model.Por_ChiTietGioHang))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Por_ChiTietGioHang;
            }
            else if (typeof(TEntity) == typeof(Model.Por_DangKyTuVan))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Por_DangKyTuVan;
            }
            else if (typeof(TEntity) == typeof(Model.Por_GioHang))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Por_GioHang;
            }
            else if (typeof(TEntity) == typeof(Model.Por_KhoaHoc))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Por_KhoaHoc;
            }
            else if (typeof(TEntity) == typeof(Model.Por_MonHoc))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Por_MonHoc;
            }
            else if (typeof(TEntity) == typeof(Model.Por_NhomAnh))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Por_NhomAnh;
            }
            else if (typeof(TEntity) == typeof(Model.Por_NhomSuKien))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Por_NhomSuKien ;
            }
            else if (typeof(TEntity) == typeof(Model.Por_NhomTinTuc))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Por_NhomTinTuc;
            }
            else if (typeof(TEntity) == typeof(Model.Por_SuKien))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Por_SuKien;
            }
            else if (typeof(TEntity) == typeof(Model.Por_ThongTinChuyenKhoan))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Por_ThongTinChuyenKhoan;
            }
            else if (typeof(TEntity) == typeof(Model.Por_TinTuc))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Por_TinTuc;
            }
            else if (typeof(TEntity) == typeof(Model.Por_GiaoVien))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Por_GiaoVien;
            }
            else if (typeof(TEntity) == typeof(Model.Por_LoaiKhoaHoc))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Por_LoaiKhoaHoc;
            }
            else if (typeof(TEntity) == typeof(Model.Por_CauHinhGiaoDien))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Por_CauHinhGiaoDien;
            }
            else if (typeof(TEntity) == typeof(Model.Por_Video))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Por_Video;
            }
            else if (typeof(TEntity) == typeof(Model.Por_NhomVideo))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Por_NhomVideo;
            }
            else if (typeof(TEntity) == typeof(Model.Por_KhoaHoc_GiaoAn))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Por_KhoaHoc_GiaoAn;
            }
            else if (typeof(TEntity) == typeof(Model.Por_GiaoAnLyThuyet))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Por_GiaoAnLyThuyet;
            }
            else if (typeof(TEntity) == typeof(Model.Por_GiaoAnThucHanh))
            {
                _serviceBase = (IRepositoryBase<TEntity>)service.Por_GiaoAnThucHanh;
            }
            #endregion
        }
        public async Task<TEntity> SaveEntityAsync(TEntity entity)
        {
            return await _serviceBase.SaveEntityAsync(entity);
        }
        public async Task<TEntity[]> SaveEntitiesAsync(TEntity[] entities)
        {
            return await _serviceBase.SaveEntitiesAsync(entities);
        }        
        public async Task<Paged<TEntity>> SearcListEntitiesAsync(int page, int pageSize, int totalLimitItems, Lib.Models.Searching search)
        {
            return await _serviceBase.SearcListEntitiesAsync(page, pageSize, totalLimitItems, search);
        }
        public async Task<Paged<TEntity>> GetListEntitiesAsync(int page, int pageSize, int totalLimitItems, string searchBy = "", string orderBy = "")
        {
            return await _serviceBase.GetListEntitiesAsync(page, pageSize, totalLimitItems, searchBy, orderBy);
        }
        public List<TEntity> GetCategoryEntities()
        {
            return _serviceBase.GetCategoryEntities();
        }
        public async Task<TEntity> GetEntityByIdAsync(Guid id)
        {
            return await _serviceBase.GetEntityByIdAsync(id);
        }
        public async Task DeleteSaveEntities(List<TEntity> entity)
        {
            await _serviceBase.DeleteSaveEntities(entity);
        }
    }
}
