using HRMSProject.Data;
using HRMSProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSProject.Repository
{
    public class DepartmentRepository
    {

       

            private readonly HRMSDbContext _hRMSDbContext = null;

            public DepartmentRepository(HRMSDbContext hRMSDbContext)
            {
                _hRMSDbContext = hRMSDbContext;
            }
            public async Task<int> AddDepartmentSetup(VmDepartment model)
            {
                var Dptype = new Department()
                {
                    DepartmentId = model.DepartmentId,
                    DepartmentName = model.DepartmentName,
                    BranchId = model.BranchId,
                   
                };

                await _hRMSDbContext.Departments.AddAsync(Dptype);
                await _hRMSDbContext.SaveChangesAsync();
                return Dptype.DepartmentId;

            }
            public async Task<List<VmDepartment>> GetAllDepartmentSetup()
            {
                return await _hRMSDbContext.Departments
                      .Select(dpt => new VmDepartment()
                      {
                          DepartmentId = dpt.DepartmentId,
                          DepartmentName = dpt.DepartmentName,
                          BranchId = dpt.BranchId
                      }).ToListAsync();
            }
            public async Task<VmDepartment> GetAllDepartmentId(int id)
            {
                return await _hRMSDbContext.Departments.Where(x => x.DepartmentId == id)
                  .Select(dpt => new VmDepartment()
                  {
                      DepartmentId = dpt.DepartmentId,
                      DepartmentName = dpt.DepartmentName,
                      BranchId = dpt.BranchId,
                     
                  }).FirstOrDefaultAsync();
            }
            public async Task<int> EditDepartmentSetup(VmDepartment model)
            {
                var result = await _hRMSDbContext.Departments
                   .FirstOrDefaultAsync(e => e.DepartmentId == model.DepartmentId);

                if (result != null)
                {
                    result.DepartmentId = model.DepartmentId;
                    result.DepartmentName = model.DepartmentName;
                    result.BranchId = model.BranchId;
                   
                    await _hRMSDbContext.SaveChangesAsync();
                    return result.DepartmentId;
                }
                return result.DepartmentId;
            }

            public async Task<VmDepartment> DeleteDepartmentId(int Id)
            {
                var result = await _hRMSDbContext.Departments
                    .FirstOrDefaultAsync(e => e.DepartmentId == Id);

                if (result != null)
                {
                    _hRMSDbContext.Departments.Remove(result);
                    await _hRMSDbContext.SaveChangesAsync();
                }

                return null;
            }

            public async Task<VmDepartment> Details(int id)
            {
                return await _hRMSDbContext.Departments.Where(x => x.DepartmentId == id)
                  .Select(cmp => new VmDepartment()
                  {
                      DepartmentId = cmp.DepartmentId,
                      DepartmentName = cmp.DepartmentName,
                      BranchId = cmp.BranchId
                    
                  }).FirstOrDefaultAsync();
            }
        }
    }
