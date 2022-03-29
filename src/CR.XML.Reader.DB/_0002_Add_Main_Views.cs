using FluentMigrator;

namespace CR.XML.Reader.DB
{
    [Migration(2, "Add the main views")]
    public class _0002_Add_Main_Views : Migration
    {
        public override void Down()
        {
            Execute.Sql(RawQuery.DropHeaderView);

            Execute.Sql(RawQuery.DropDetailView);

            Execute.Sql(RawQuery.DropComercialCodeView);

            Execute.Sql(RawQuery.DropTaxesView);

            Execute.Sql(RawQuery.DropTotalsView);
        }

        public override void Up()
        {
            Execute.Sql(RawQuery.CreateHeaderView);

            Execute.Sql(RawQuery.CreateDetailView);

            Execute.Sql(RawQuery.CreateComerialCodeView);

            Execute.Sql(RawQuery.CreateTaxesView);

            Execute.Sql(RawQuery.CreateTotalsView);
        }
    }
}
