//
// MixedPriceInItemException.cs
//
// Author:
//   Vladimir Dimitrov <vlad.dimitrov at gmail dot com>
//
// Created:
//   03/04/2007
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

using System;

namespace Warehouse.Data
{
    /// <summary>
    /// The exception that is thrown when some goods is of insufficient quantity.
    /// </summary>
    public class MixedPriceInItemException : Exception
    {
        /// <summary>
        /// Gets or sets the name of the goods of insufficient quantity.
        /// </summary>
        /// <value>The name of the goods of insufficient quantity.</value>
        public string ItemName { get; set; }

        /// <summary>
        /// The exception that is thrown when the specified goods is of insufficient quantity.
        /// </summary>
        /// <param name="itemName">The name of the goods of insufficient quantity.</param>
        public MixedPriceInItemException (string itemName)
            : base (string.Format("Insufficient quantity of item \"{0}\"", itemName))
        {
            ItemName = itemName;
        }
    }
}
