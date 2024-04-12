using InvoiceAppApi.Models;

namespace InvoiceAppApi.Interffaces
{
    public interface IcustomerRepository
    {
        ICollection<Customer> GetCustomerList();
        ICollection<ItemName> GetItemList();
        ICollection<RoleClass> GetRoleList();
        ICollection<PaymentModeModel> GetPaymentModeList();
        ICollection<PaymentModeModel> GetPaymentModeList2();

        ICollection<MenuModel> GetAllMenuList();


        ICollection<User2> GetAllUserList();
        ICollection<Rolepermissions> GetRolePermissions(int RoleId);
        ICollection<Rolepermissions> GetUserPermission(int RoleID);




        bool EditItemName(ItemName Item);
        bool DeleteItemName(int Id);
        bool AddItemname(ItemName Item);
        bool EditCustomerName(Customer Customer);
        bool DeleteCustomer(int Id);
        bool AddCustomer(Customer Customer);
        bool EditRoleName(RoleClass Role);
        bool DeleteRole(int Id);
        bool AddRole(RoleClass Role);

        bool EditUser(User User);
        bool DeleteUser(int Id);

        bool AddUser(User User);
        bool EditMenu(MenuModel Menu);
        bool DeleteMenu(int Id);

        bool AddMenu(MenuModel Menu);
        bool GiveRole(GiveRole Role);

        bool EditPermissions(List<Rolepermissions> Permissions); 

        bool AddPaymentMode(PaymentModeModel PaymentMode);
        bool DeletePaymentMode(int Id);
        bool EditPaymentModed(PaymentModeModel PaymentMode);

    }
}
