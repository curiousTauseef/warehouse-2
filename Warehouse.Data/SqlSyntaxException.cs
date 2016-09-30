//
// SQLSyntaxException.cs
//
// Author:
//   Vladimir Dimitrov (vlad.dimitrov at gmail dot com)
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
    public class SqlSyntaxException : Exception
    {
        private string sqlCommand;
        private int line;

        public string SqlCommand
        {
            get { return sqlCommand; }
            set { sqlCommand = value; }
        }

        public int Line
        {
            get { return line; }
            set { line = value; }
        }

        public SqlSyntaxException (string sqlCommand)
            : base (string.Format("Sytax error in sql \"{0}\"", sqlCommand))
        {
            this.sqlCommand = sqlCommand;
        }

        public SqlSyntaxException (string sqlCommand, int line, Exception innerException)
            : base (string.Format ("Sytax error in sql \"{0}\" on line {1}", sqlCommand, line), innerException)
        {
            this.sqlCommand = sqlCommand;
            this.line = line;
        }
    }
}
