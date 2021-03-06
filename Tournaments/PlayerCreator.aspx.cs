﻿using Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tournaments.Models;
using Tournaments.Models_project;
using Tournaments.Presenters;
using Tournaments.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace Tournaments
{
    [PresenterBinding(typeof(PlayerPresenter))]
    public partial class PlayerCreator : MvpPage<PlayerViewModel>, IPlayerView
    {
        public event EventHandler MyInit;
        public event EventHandler OnGetData;
        public event EventHandler OnInsertItem;
        public event EventHandler<IdEventArgs> OnDeleteItem;
        public event EventHandler<IdEventArgs> OnUpdateItem;
        public event EventHandler<GenericEventArgs<Player>> OnCreateItem;
        public event EventHandler<GenericEventArgs<Player>> SendPlayer;

        protected void Page_Load(object sender, EventArgs e)
        {
        }
 
        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression

        public IQueryable<Player> GridViewTeams_GetData()
        {
            this.OnGetData?.Invoke(this, null);

            return this.Model.Players.AsQueryable();
        }

        public void GridViewTeams_InsertItem()
        {
            this.OnInsertItem?.Invoke(this, null);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewTeams_DeleteItem(int? id)
        {

            this.OnDeleteItem?.Invoke(this, new IdEventArgs(id));
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewTeams_UpdateItem(int? id)
        {
            this.OnUpdateItem?.Invoke(this, new IdEventArgs(id));
        }

        private void EnableGridViewButtions(GridView view, string role)
        {
            //if the role is needed, just add ViewContext.HttpContext.User.IsInRole("Your role")
            bool isLoggedIn = (HttpContext.Current.User != null) &&
                HttpContext.Current.User.Identity.IsAuthenticated;

            if (isLoggedIn)
            {
                view.AutoGenerateEditButton = true;
                view.AutoGenerateDeleteButton = true;
            }
        }

        public void CreatePlayerBtn_Click(object sender, EventArgs e)
        {
            string Url = (string)Session["Url"]; 
            Player player = null; //new Player() { Name = "NNNN" };
            this.OnCreateItem?.Invoke(this, new GenericEventArgs<Player>(player));
        }
    }
}