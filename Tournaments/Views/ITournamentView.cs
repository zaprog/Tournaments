﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournaments.Models_project;
using WebFormsMvp;

namespace Tournaments.Views
{
    public interface ITournamentView : IView<TournamentViewModel>
    {
        event EventHandler MyInit;
    }
}
