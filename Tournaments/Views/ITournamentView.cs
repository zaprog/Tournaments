﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using Tournaments.Models_project;
using WebFormsMvp;

namespace Tournaments.Views
{
    public interface ITournamentView : IView<TournamentViewModel>
    {
        event EventHandler MyInit;
        event EventHandler OnGetData;
        event EventHandler OnInsertItem;
        event EventHandler<IdEventArgs> OnDeleteItem;
        event EventHandler<IdEventArgs> OnUpdateItem;

        ModelStateDictionary ModelState { get; }

        bool TryUpdateModel<TModel>(TModel model) where TModel : class;
    }
}
