//
// ListView.Container.cs
//
// Author:
//   Vladimir Dimitrov <vlad.dimitrov at gmail dot com>
//
// Created:
//   09/23/2008
//
// 2006-2015 (C) Microinvest, http://www.microinvest.net
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA

using System.Collections.Generic;
using System.Linq;
using Gtk;

namespace Warehouse.Component.ListView
{
    public partial class ListView
    {
        private readonly List<Widget> widgets = new List<Widget> ();

        protected override void OnAdded (Widget widget)
        {
            if (widgets.Any (w => w == widget))
                return;
            
            // Base throws Gtk Warning thinking we have not overwritten this methow
            //base.OnAdded (widget);
            widgets.Add (widget);
            if (widget.Parent == null)
                widget.Parent = this;
        }

        protected override void OnRemoved (Widget widget)
        {
            base.OnRemoved (widget);

            if (widgets.Remove (widget))
                widget.Unparent ();
        }

        protected override void ForAll (bool include_internals, Callback callback)
        {
            foreach (Widget widget in new List<Widget> (widgets))
                callback (widget);
        }
    }
}
