//
// StartupPage.cs
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

using System;
using Mono.Addins;
using Warehouse.Component.WorkBook;

namespace Warehouse.Presentation
{
    [TypeExtensionPoint ("/Warehouse/Presentation/WorkBook")]
    public class StartupPage
    {
        private readonly string name;
        private readonly string className;

        public string Name
        {
            get { return name; }
        }

        public string ClassName
        {
            get { return className; }
        }

        public virtual Type InstanceType
        {
            get { return Type.GetType (className); }
        }

        public StartupPage (string name, string className)
        {
            this.name = name;
            this.className = className;
        }

        public StartupPage (string name, Type type)
        {
            if (type == null || !type.IsSubclassOf (typeof (WorkBookPage)))
                throw new ArgumentNullException ("type");

            this.name = name;
            className = type.FullName;
        }

        public WbpBase CreateInstance ()
        {
            Type pageType = InstanceType ?? GetType ().Assembly.GetType (className);

            if (pageType != null)
                return Activator.CreateInstance (pageType) as WbpBase;

            return null;
        }
    }
}
