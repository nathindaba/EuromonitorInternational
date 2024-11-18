using Euromonitor.Models;
using Euromonitor.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euromonitor.Services.Interfaces;

public interface IUser
{
    Task<Response> AddUser(string createdBy, string updatedBy, User model, string role, string companyId = null);
    Task<Response> GetCategories(string role, string companyId = null);
    Task<Response> UpdateCategory(string updatedBy, User model, string role, string companyId = null);
    Task<Response> SoftDeleteCategory(string updatedBy, string id, string role, string companyId = null);
    Task<Response> GetCategory(string id, string role, string companyId = null);
}