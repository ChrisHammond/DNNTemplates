using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using $rootnamespace$$safeprojectname$.Components;
using $rootnamespace$$safeprojectname$.Services.ViewModels;
using DotNetNuke.Common;
using DotNetNuke.Web.Api;
using DotNetNuke.Security;
using System.Threading;
using DotNetNuke.UI.Modules;
using DotNetNuke.Common.Utilities;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Dnn.Modules.$safeprojectname$.Services
{
    [Supporte$rootnamespace$dModules("$safeprojectname$")]
    [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.View)]

    public class ItemController : DnnApiController
    {
        private readonly IItemRepository _repository;

        public ItemController(IItemRepository repository)
        {
            Requires.NotNull(repository);

            this._repository = repository;
        }

        public ItemController() : this(ItemRepository.Instance) { }

        public HttpResponseMessage Delete(int itemId)
        {
            var item = _repository.GetItem(itemId, ActiveModule.ModuleID);

            _repository.DeleteItem(item);

            return Request.CreateResponse(System.Net.HttpStatusCode.NoContent);
        }

        public HttpResponseMessage Get(int itemId)
        {
            var item = new ItemViewModel(_repository.GetItem(itemId, ActiveModule.ModuleID));

            return Request.CreateResponse(item);
        }

        public HttpResponseMessage GetList()
        {
            List<ItemViewModel> items;

            if (Globals.IsEditMode())
            {
                items = _repository.GetItems(ActiveModule.ModuleID)
                       .Select(item => new ItemViewModel(item, GetEditUrl(item.ItemId)))
                       .ToList();
            }
            else
            {
                items = _repository.GetItems(ActiveModule.ModuleID)
                       .Select(item => new ItemViewModel(item, ""))
                       .ToList();
            }

            return Request.CreateResponse(items);
        }

        protected string GetEditUrl(int id)
        {
            string editUrl = Globals.NavigateURL("Edit", string.Format("mid={0}", ActiveModule.ModuleID), string.Format("tid={0}", id));

            if (PortalSettings.EnablePopUps)
            {
                editUrl = UrlUtils.PopUpUrl(editUrl, PortalSettings, false, false, 550, 950);
            }
            return editUrl;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public HttpResponseMessage Upsert(ItemViewModel item)
        {
            if (item.Id > 0)
            {
                var t = Update(item);
                return Request.CreateResponse(System.Net.HttpStatusCode.NoContent);
            }
            else
            {
                var t = Create(item);
                return Request.CreateResponse(t.ItemId);
            }
            
        }

        private Item Create(ItemViewModel item)
        {
            Item t = new Item
            {
                ItemName = item.Name,
                ItemDescription = item.Description,
                AssignedUserId = item.AssignedUser,
                ModuleId = ActiveModule.ModuleID,
                CreatedByUserId = UserInfo.UserID,
                LastModifiedByUserId = UserInfo.UserID,
                CreatedOnDate = DateTime.UtcNow,
                LastModifiedOnDate = DateTime.UtcNow
            };
            _repository.AddItem(t);

            return t;
        }

        private Item Update(ItemViewModel item)
        {

            var t = _repository.GetItem(item.Id, ActiveModule.ModuleID);
            if (t != null)
            {
                t.ItemName = item.Name;
                t.ItemDescription = item.Description;
                t.AssignedUserId = item.AssignedUser;
                t.LastModifiedByUserId = UserInfo.UserID;
                t.LastModifiedOnDate = DateTime.UtcNow;
            }
            _repository.UpdateItem(t);

            return t;
        }
    }
}
