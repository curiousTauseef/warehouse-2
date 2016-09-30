//
// CellEditEndEventArgs.cs
//
// Author:
//   Vladimir Dimitrov <vlad.dimitrov at gmail dot com>
//
// Created:
//   10/18/2007
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

namespace Warehouse.Component.ListView
{
    public class CellEditEndEventArgs : CellEventArgs
    {
        private object newValue;

        public object NewValue
        {
            get { return newValue; }
            set { newValue = value; }
        }

        public CellEditEndEventArgs (int column, int row, object newValue)
            : base (column, row)
        {
            this.newValue = newValue;
        }
    }
}
