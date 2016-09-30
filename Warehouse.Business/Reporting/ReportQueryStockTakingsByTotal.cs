//
// ReportQueryStockTakingsByTotal.cs
//
// Author:
//   Vladimir Dimitrov <vdimitrov at vladster dot net>
//
// Created:
//   09.30.2010
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

using Warehouse.Data;

namespace Warehouse.Business.Reporting
{
    public class ReportQueryStockTakingsByTotal : ReportQueryBase
    {
        public ReportQueryStockTakingsByTotal ()
        {
            Name = Translator.GetString ("Stock-taking by Amount Report");

            AppendFilter (new FilterDateRange (true, true, DataFilterLabel.OperationDate, DataField.OperationDate));
            AppendFilter (new FilterFind (false, true, DataFilterLabel.ItemCode, DataField.ItemCode));
            AppendFilter (new FilterFind (false, true, DataFilterLabel.ItemName, DataField.ItemName));
            AppendFilter (new FilterFind (false, true, DataFilterLabel.ItemBarcode, DataField.ItemBarcode1, DataField.ItemBarcode2, DataField.ItemBarcode3));
            AppendFilter (new FilterFind (false, true, DataFilterLabel.ItemCatalog, DataField.ItemCatalog1, DataField.ItemCatalog2, DataField.ItemCatalog3));
            AppendFilter (new FilterGroupFind (false, true, DataFilterLabel.ItemsGroupName, DataField.ItemsGroupName));
            AppendFiltersForLots ();
            AppendFilter (new FilterFind (false, true, DataFilterLabel.LocationName, DataField.LocationName));
            AppendFilter (new FilterGroupFind (false, true, DataFilterLabel.LocationsGroupName, DataField.LocationsGroupsName));
            AppendFilter (new FilterFind (false, true, DataFilterLabel.OperationsOperatorName, DataField.OperationsOperatorName));
            AppendFilter (new FilterGroupFind (false, true, DataFilterLabel.OperationsOperatorsGroupsName, DataField.OperationsOperatorsGroupsName));
        }

        #region Overrides of ReportQueryBase

        public override DataQueryResult ExecuteReport (DataQuery dataQuery)
        {
            return BusinessDomain.DataAccessProvider.ReportStockTakingsByTotal (dataQuery);
        }

        #endregion
    }
}
