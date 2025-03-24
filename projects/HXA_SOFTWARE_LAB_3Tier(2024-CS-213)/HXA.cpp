#include <iostream>
#include <fstream>
#include <windows.h>
#include <conio.h>
using namespace std;

// all users records: name email password
string admin_credentials[2][3];
string customer_credentials[100][3];
int total_buyers = 0, total_admins = 0, user_type = -1;

// order record: orederer_id, type(service), platform, p_budget, time, description, status, revenue_generated, title(if present it is special project)
string order_records[100][10];
int last_order_no = 0;

// PROTOTYPES

void gotoxy(int x, int y);
int checked_input(int interval_start, int interval_end, int x, int y);

// interface printing functions
void intro();
void print_header();
void login_page();
void SignUp_page();
void print_our_services_start();
void print_our_services_end();
void print_update_order_status();
void print_search_order_email();
void print_order_description();
void print_order_platform();
void print_order_budget();
void print_order_submit_proposal();
void print_order_Timeline();
void print_add_reviews();
void print_reviews_header();

// menu printing functions
void entry_Menu();
void main_admin_Menu(int user_index);
void admin_Menu(int user_index);
void buyer_Menu(int user_index);
void manage_services_Menu();
void top_projects_menu();
void manage_sales_menu();
void manage_order_Menu();
void print_review_Menu();
// void print_order_type();
// int customer_registration(string username,string email,string password,int total_buyers);

// printing dynamic data(use methods like loops)
void print_sentence(string sentence, int lenght);
void display_service(string services_arr[][4], int ser_idx);
void print_all_orders();
void generate_order_summary();
string display_order(int index);
void display_top_projects();
void print_order_book(int order_indexes[], int total_orders);
void print_admin_dashboard(int completed_order, int revenue, string popular_service, string new_order, string feedback);
void print_sales_analytics(int revenue, string popular_service, string top_customer, int completed_orders, int avg_budget);
void print_add_sales_analytics(int x, int y, string services[][4], int col, int last_service);
void print_order_type(int &y, string services[][4], int last_service);
int print_review(string reviews[][4], int review_idx, int review_y);

// processing calculation
int input_scanner(string email, int total_buyers, int total_admins);
int email_authenticator(string email, string password, int total_admins, int total_customers);
int search_services(string services[][4], int last_service_no);
int admin_deletion(int index, int total_admins);
int customer_deletion(int index, int total_buyers);
int calculate_total_revenue();
int calculate_completed_orders();
int calculate_Uncompleted_orders();
int search_order_by_id(string id);
string get_order_platform(int order_choice);
string get_order_budget(int order_choice);
string get_order_type(int order_choice, string services[][4], int last_service);
string sales_string_auto_manual_handler(string auto_value, string manual_value);
string calculate_order_status(int index);
string get_order_date(int start_date, int start_month, int start_year, int completion_date, int completion_month, int completion_year);
string calculate_most_frequent_element(string array[][10], int col, int size);
void delete_order();
bool email_validation(string email);
bool password_validation(string password);
bool order_fetcher(string customer, string orderer);

// file handelling
void get_credentials(string filename, string credentials[][3], int &count);
void register_credentials(string credentials[], int user_type, int &count);
void update_credentials(string filename, string arr[][3], int &count);
string getField(string data, int field_count, char seperator);
void get_data(string filename, string arr[][10], int &count);
void update_data(string filename, string arr[][10], int &count);
void get_data(string filename, string arr[][4], int &count);
void update_data(string filename, string arr[][4], int &count);


void seller_Menu(int user_index);

int main()
{
    string credentials[3];
    bool completion = false;
    int choice = -1, b_choice = -1, a_choice = -1, services_choice = -1, t_project_choice = -1, sales_analytics_choice = -1, order_choice = -1, nav = -1, user_index = -1;
    string o_type, o_platform, o_budget, o_description, o_time;
    int founded_order_indexes[100], total_found = 0, order_placing = 0;
    // reviews_record: reviewer, stars, date, description
    string review_records[100][4];
    // string reviewer[100] = {"John Doe","Jane Smith","Robert Lee"};
    // int review_stars[100] = {5,5,5};
    // string review_date[100] = {"October 12, 2024","September 25, 2024","August 10, 2024"};
    // string review_description[100] = {"The software house delivered beyond expectations. The project was managed seamlessly, and the team went above and beyond to meet our requirements","I hired them for a website development project. The team was highly professional, communicative, and provided valuable insights throughout","They delivered the app on time, and it performed flawlessly. The customer support was available even post-launch, which was incredibly helpful"};
    int r_choice = -1, last_review = 3, last_page_review = last_review - 3;
    // services_record: type, description, technologies(involved i.e; languages,libraries & can also be null), services_involved
    string services_records[20][4];
    int last_service_no = 6, s_idx = -1;
    // manage order records
    int m_order_choice = -1;
    // sales analytics
    int m_total_revenue = 0, m_completed_orders = 0, t_c_index = -1;
    string m_popular_service = "auto", m_top_customer = "auto";

    system("cls");
    system("color 0f");
    intro();
    system("cls");
    get_credentials("admins.txt", admin_credentials, total_admins);
    get_credentials("customers.txt", customer_credentials, total_buyers);
    get_data("orders.txt", order_records, last_order_no);
    get_data("services.txt", services_records, last_service_no);
    get_data("reviews.txt", review_records, last_review);

    while (!completion)
    {
        Sleep(100);
        print_header();
        // without login
        if (user_type == -1)
        {
            if (choice == -1)
            {
                entry_Menu();
                cin >> choice;
                if (choice == 2)
                {
                    cout << "Please LogIn first...\n";
                    choice = -1;
                }
            }
            else if (choice == 1)
            {
                print_our_services_start();
                for (int i = last_service_no - 1, k = 1; i > -1; i--, k++)
                {
                    cout << k << ". ";
                    display_service(services_records, i);
                }
                print_our_services_end();

                cout << "\n\nPress any key for Main Menu...";
                choice = -1;
            }
            else if (choice == 3)
            {
                login_page();
                gotoxy(28, 12);
                cin >> credentials[1];
                gotoxy(28, 15);
                cin >> credentials[2];
                // cout<<user_type<<endl;
                user_index = email_authenticator(credentials[1], credentials[2], total_admins, total_buyers);
                // cout<<user_type<<endl;
                if (user_type == -1)
                {
                    gotoxy(0, 22);
                    cout << "Invalid credentials\n";
                    choice = -1;
                }
            }
            else if (choice == 4)
            {
                SignUp_page();
                gotoxy(28, 12);
                cin >> credentials[0];
                gotoxy(28, 15);
                cin >> credentials[1];
                if (!email_validation(credentials[1]))
                {
                    gotoxy(0, 22);
                    cout << "invalid email...!";
                }
                else
                {
                    gotoxy(28, 18);
                    cin >> credentials[2];
                    if (!password_validation(credentials[2]))
                    {
                        gotoxy(0, 22);
                        cout << "A password must have 8 to 16 characters with letters, numbers and special characters...!";
                    }
                    else
                    {
                        user_index = input_scanner(credentials[1], total_buyers, total_admins);
                        if (user_index != -1)
                        {
                            cout << "Email already exist...\n";
                            user_index = -1;
                        }
                        else if (user_index == -1)
                        {
                            register_credentials(credentials, 2, total_buyers);
                        }
                    }
                }
                user_type = -1;
                choice = -1;
            }
            if (choice == 5)
            {
                completion = true;
            }
        }
        else
        {
            // admin
            if (user_type == 1)
            { // order management
                if (a_choice == -1)
                {
                    if (user_index == 0)
                    {
                        main_admin_Menu(user_index);
                        a_choice = checked_input(1, 11, 19, 21);
                    }
                    else
                    {
                        admin_Menu(user_index);
                        a_choice = checked_input(1, 7, 19, 17);
                    }
                }
                else if (a_choice == 1)
                {
                    int total_revenue0 = 0, total_revenue = 0, completed_orders = 0;
                    string popular_service0 = "", popular_service = "", feedback, new_order;
                    completed_orders = calculate_completed_orders();
                    total_revenue0 = calculate_total_revenue();
                    popular_service0 = calculate_most_frequent_element(order_records, 2, last_order_no);
                    popular_service = sales_string_auto_manual_handler(popular_service0, m_popular_service);
                    total_revenue = total_revenue0 + m_total_revenue;
                    feedback = review_records[last_review - 1][3];

                    if (order_records[last_order_no - 1][7] != "1")
                        new_order = order_records[last_order_no - 1][1];
                    else
                        new_order = "No Orders";

                    print_admin_dashboard(completed_orders, total_revenue, popular_service, new_order, feedback);

                    cin.ignore();
                    cin >> choice;
                    if (choice == 1)
                    {
                        a_choice = 2;
                        m_order_choice = 1;
                        choice = -1;
                    }
                    else if (choice == 2)
                    {
                        a_choice = 5;
                        t_project_choice = 2;
                        choice = -1;
                    }
                    else if (choice == 3)
                    {
                        a_choice = 4;
                        sales_analytics_choice = 1;
                        choice = -1;
                    }
                    else if (choice == 4)
                    {
                        a_choice = -1;
                        choice = -1;
                    }
                    else
                    {
                        cout << "wrong input";
                        choice = -1;
                    }
                }
                else if (a_choice == 2)
                {
                    if (m_order_choice == -1)
                    {
                        manage_order_Menu();
                        m_order_choice = checked_input(1, 6, 19, 18);
                    }
                    else if (m_order_choice == 1)
                    {
                        print_all_orders();
                        m_order_choice = -1;
                    }
                    else if (m_order_choice > 1 && m_order_choice < 5)
                    {
                        string id, email;
                        int index = -1, choice = -1, revenue, founded_order_indexes[100], total_found = 0;
                        bool status = false;

                        if (m_order_choice == 2)
                        {
                            print_update_order_status();
                            cin >> id;
                            index = search_order_by_id(id);
                            if (index == -1)
                                cout << "Not Found...!\n";
                            else
                            {
                                cout << "\nCurrent Status: ";
                                cout << calculate_order_status(index);
                                cout << "\nMark as (1. Completed, 2. Uncompleted): ";
                                choice = checked_input(1, 2, 40, 15);
                                if (choice == 1)
                                {
                                    cout << "\nAdd Order Revenue: $";
                                    revenue = checked_input(10, 100000, 20, 17);
                                    order_records[index][8] = to_string(revenue);
                                    order_records[index][7] = "1";
                                }
                                else if (choice == 2)
                                    order_records[index][7] = "0";
                                update_data("orders.txt", order_records, last_order_no);
                                cout << "\nStatus Updated Successfully!\n";
                            }
                        }
                        else if (m_order_choice == 3)
                        {
                            delete_order();
                            cin >> id;
                            index = search_order_by_id(id);
                            if (index == -1)
                                cout << "Not Found...!\n";
                            else
                            {
                                cout << "\n"
                                     << display_order(index);
                                cout << "\nAre you sure you want to delete (1. Yes, 2. No): ";
                                choice = checked_input(1, 2, 49, 21);
                                if (choice == 1)
                                {
                                    last_order_no--;
                                    for (int j = 0; j < 10; j++)
                                        order_records[index][j] = order_records[last_order_no][j];
                                    update_data("orders.txt", order_records, last_order_no);
                                    cout << "Deleted!";
                                }
                            }
                        }
                        else if (m_order_choice == 4)
                        {
                            print_search_order_email();
                            cin >> email;
                            index = input_scanner(email, total_buyers, total_admins);
                            if (index == -1)
                            {
                                cout << "\nEmail not found...!";
                            }
                            else
                            {
                                cout << endl;
                                for (int i = 0; i < last_order_no; i++)
                                {
                                    if (customer_credentials[index][1] == order_records[i][0])
                                    {
                                        founded_order_indexes[total_found] = i;
                                        total_found++;
                                    }
                                }
                                for (int i = total_found - 1; i >= 0; i--)
                                {
                                    cout << display_order(founded_order_indexes[i]) << endl;
                                }
                            }
                        }
                        cout << "\n================================================================================================\n";
                        cout << "\nEnter your choice (1. Search again, 2. Previous page): ";
                        cin >> choice;
                        if (choice == 2)
                            m_order_choice = -1;
                        else if (choice == 1)
                            ;
                        else
                        {
                            cout << "Wrong input...!";
                        }
                    }
                    else if (m_order_choice == 5)
                    {
                        generate_order_summary();
                        m_order_choice = -1;
                    }
                    if (m_order_choice == 6)
                    {
                        a_choice = -1;
                        m_order_choice = -1;
                    }
                    choice = -1;
                }
                else if (a_choice == 3)
                {
                    string ser_record[4];
                    if (services_choice == -1)
                    {
                        manage_services_Menu();
                        services_choice = checked_input(1, 5, 20, 14);
                    }
                    else if (services_choice == 2)
                    {
                        print_our_services_start();
                        for (int i = last_service_no - 1, k = 1; i > -1; i--, k++)
                        {
                            cout << k << ". ";
                            display_service(services_records, i);
                        }
                        print_our_services_end();
                        services_choice = -1;
                    }
                    else if (services_choice == 3)
                    { // add services
                        cout << "Type:\n\t";
                        cin.ignore();
                        getline(cin, ser_record[0]);
                        cout << "Description(150 characters max):\n\t";
                        getline(cin, ser_record[1]);
                        cout << "Technologies/process(write 'null' if nothing):\n\t";
                        getline(cin, ser_record[2]);
                        if (ser_record[2] == "null")
                            ser_record[2] = "\0";
                        cout << "Services:\n\t";
                        getline(cin, ser_record[3]);
                        cout << "Enter (1. add services,2. previous page): ";
                        choice = checked_input(1, 2, 42, 16);
                        if (choice == 1)
                        {
                            services_records[last_service_no][0] = ser_record[0];
                            services_records[last_service_no][1] = ser_record[1];
                            services_records[last_service_no][2] = ser_record[2];
                            services_records[last_service_no][3] = ser_record[3];
                            last_service_no++;
                            update_data("services.txt", services_records, last_service_no);
                        }
                        choice = -1;
                        services_choice = -1;
                    }
                    else if (services_choice == 4)
                    { // deleting services

                        s_idx = search_services(services_records, last_service_no);
                        cout << endl;
                        if (s_idx == -1)
                        {
                            cout << "Not Found...!\n";
                        }
                        else
                        {
                            display_service(services_records, s_idx);
                            gotoxy(0, 17);
                            cout << "Delete Service (1. Yes,2. No): ";
                            choice = checked_input(1, 2, 31, 17);
                            if (choice == 1)
                            {
                                for (int i = 0; i < 4; i++)
                                    services_records[s_idx][i] = services_records[last_service_no - 1][i];
                                last_service_no--;
                                update_data("services.txt", services_records, last_service_no);
                            }
                        }
                        gotoxy(0, 19);
                        cout << "Enter (1. search again,2. Previous page): ";
                        choice = checked_input(1, 2, 42, 19);
                        if (choice == 2)
                            services_choice = -1;
                        choice = -1;
                    }
                    else if (services_choice == 5)
                    { // replacing
                        s_idx = search_services(services_records, last_service_no);
                        cout << endl;
                        if (s_idx == -1)
                        {
                            cout << "\nNot Found...!\n";
                        }
                        else
                        {
                            display_service(services_records, s_idx);
                            cout << "\nNew Type:\n\t";
                            cin.ignore();
                            getline(cin, ser_record[0]);
                            cout << "New Description(150 characters max):\n\t";
                            getline(cin, ser_record[1]);
                            cout << "New Technologies/process(write 'null' if nothing):\n\t";
                            getline(cin, ser_record[2]);
                            cout << "New Services:\n\t";
                            getline(cin, ser_record[3]);
                            cout << "\nReplace Service (1. Yes,2. No): ";
                            choice = checked_input(1, 2, 32, 25);
                            if (choice == 1)
                            {
                                services_records[s_idx][0] = ser_record[0];
                                services_records[s_idx][1] = ser_record[1];
                                services_records[s_idx][2] = ser_record[2];
                                services_records[s_idx][3] = ser_record[3];
                                update_data("services.txt", services_records, last_service_no);
                            }
                        }
                        gotoxy(0, 27);
                        cout << "Enter (1. search again,2. Previous page): ";
                        choice = checked_input(1, 2, 42, 27);
                        if (choice == 2)
                            services_choice = -1;
                        choice = -1;
                    }
                    if (services_choice == 1)
                    {
                        a_choice = -1;
                        services_choice = -1;
                    }
                }
                else if (a_choice == 4)
                {
                    if (sales_analytics_choice == -1)
                    {
                        manage_sales_menu();
                        sales_analytics_choice = checked_input(1, 3, 19, 15);
                    }
                    else if (sales_analytics_choice == 1)
                    {
                        int total_revenue0 = 0, total_revenue = 0, avg_budget = 0, completed_orders0 = 0, completed_orders = 0;
                        string popular_service0 = "", top_customer0 = "", popular_service = "", top_customer = "";
                        total_revenue0 = calculate_total_revenue();
                        popular_service0 = calculate_most_frequent_element(order_records, 2, last_order_no);
                        top_customer0 = calculate_most_frequent_element(order_records, 0, last_order_no);
                        completed_orders0 = calculate_completed_orders();

                        total_revenue = total_revenue0 + m_total_revenue;
                        completed_orders = completed_orders0 + m_completed_orders;
                        if (completed_orders == 0)
                            avg_budget = 0;
                        else
                            avg_budget = total_revenue / completed_orders;
                        popular_service = sales_string_auto_manual_handler(popular_service0, m_popular_service);
                        // if(m_popular_service == "auto")
                        // popular_service = popular_service0;
                        // else
                        // popular_service = m_popular_service;
                        top_customer = sales_string_auto_manual_handler(top_customer0, m_top_customer);
                        // if(m_top_customer == "auto")
                        //     top_customer = top_customer0;
                        // else
                        //     top_customer = m_top_customer;

                        print_sales_analytics(total_revenue, popular_service, top_customer, completed_orders, avg_budget);
                        sales_analytics_choice = -1;
                    }
                    else if (sales_analytics_choice == 2)
                    {
                        int x = 25, y = 12;
                        print_add_sales_analytics(x, y, services_records, 0, last_service_no);

                        m_total_revenue = checked_input(-10000, 10000, x, y);
                        choice = checked_input(1, last_service_no + 1, x, y + 2);
                        m_popular_service = get_order_type(choice, services_records, last_service_no);
                        m_completed_orders = checked_input(-calculate_completed_orders(), 8, x + 9, y + 4);

                        gotoxy(x + 16, y + 6);
                        cin >> credentials[1];
                        if (credentials[1] == "auto")
                            m_top_customer = "auto";
                        else
                        {
                            t_c_index = input_scanner(credentials[1], total_buyers, total_admins);
                            if (t_c_index == -1)
                                cout << "\nEmail not found...!";
                            else if (customer_credentials[t_c_index][1] == calculate_most_frequent_element(order_records, 0, last_order_no))
                                cout << "\nCustomer is already a top customer";
                            else
                            {
                                cout << endl
                                     << customer_credentials[t_c_index][0] << endl
                                     << customer_credentials[t_c_index][1] << endl;
                                cout << "\nMark as (1. Top Customer,2. Regular Customer): ";
                                choice = checked_input(1, 2, x + 24, y + 11);
                                if (choice == 1)
                                    m_top_customer = customer_credentials[t_c_index][0];
                                else
                                    m_top_customer = "auto";
                            }
                        }

                        sales_analytics_choice = -1;
                        choice = -1;
                    }
                    if (sales_analytics_choice == 3)
                    {
                        a_choice = -1;
                        sales_analytics_choice = -1;
                    }
                }
                else if (a_choice == 5)
                {
                    if (t_project_choice == -1)
                    {
                        top_projects_menu();
                        t_project_choice = checked_input(1, 6, 19, 15);
                    }
                    else if (t_project_choice == 1)
                    {
                        display_top_projects();
                        t_project_choice = -1;
                    }
                    else if (t_project_choice == 2)
                    {
                        int index;
                        string id = "", title = "";
                        cout << "Enter Id to Search Order: ";
                        cin >> id;
                        index = search_order_by_id(id);
                        if (index == -1)
                        {
                            cout << "\nNot Found...!";
                        }
                        else
                        {
                            cout << endl;
                            if (order_records[index][9] != "\0")
                                cout << "Name: " << order_records[index][9] << endl;
                            cout << display_order(index);
                            cout << "\nCurrent State: ";
                            if (order_records[index][9] != "\0")
                                cout << "Featured Project\n";
                            else
                                cout << "Normal Project\n";
                            gotoxy(0, 19);
                            cout << "Mark as(1. Featured, 2. UnFeatured): ";
                            choice = checked_input(1, 2, 37, 19);
                            if (choice == 1)
                            {
                                cout << "\nEnter title: ";
                                cin.ignore();
                                getline(cin, title);
                                order_records[index][9] = title;
                            }
                            else
                                order_records[index][9] = "\0";
                            update_data("orders.txt", order_records, last_order_no);
                            cout << "\nStatus Updated Successfully...!";
                        }
                        gotoxy(0, 25);
                        cout << "Press (1. Search again, 2. Previous page): ";
                        choice = checked_input(1, 2, 43, 25);
                        if (choice == 2)
                        {
                            t_project_choice = -1;
                            choice = -1;
                        }
                    }
                    if (t_project_choice == 3)
                    {
                        a_choice = -1;
                        t_project_choice = -1;
                    }
                }
                else if (a_choice == 6)
                {
                    int review_y = 13;
                    print_reviews_header();
                    for (int i = last_review - 1; i > last_page_review; i--)
                        review_y = print_review(review_records, i, review_y);

                    cout << "Press (1. Main Menu,2. Load More): ";
                    choice = checked_input(1, 2, 35, review_y);
                    if (choice == 2)
                    {
                        if (last_page_review > -1)
                            last_page_review--;
                    }
                    else
                        a_choice = -1;
                    choice = -1;
                }
                else if (a_choice == 7)
                {
                    if (total_admins < 3)
                    {
                        int user_idx = -1;
                        SignUp_page();
                        gotoxy(28, 12);
                        cin >> credentials[0];
                        gotoxy(28, 15);
                        cin >> credentials[1];
                        gotoxy(28, 18);
                        cin >> credentials[2];
                        user_idx = input_scanner(credentials[1], total_buyers, total_admins);
                        if (user_idx != -1)
                        {
                            cout << "Email already exist...\n";
                            user_idx = -1;
                        }
                        else if (user_idx == -1)
                        {
                            register_credentials(credentials, 1, total_admins);
                        }
                        else
                        {
                            cout << "Something went wrong";
                        }
                    }
                    else
                        cout << "Max Limit of 3 admins have reached no more admins can be added";
                    a_choice = -1;
                }
                else if (a_choice == 8)
                {
                    int user_idx = -1;
                    cout << "Enter Email: ";
                    cin >> credentials[1];
                    user_idx = input_scanner(credentials[1], total_buyers, total_admins);
                    if ((user_idx != -1) && (user_idx != 0))
                    {
                        cout << "\nName: " << admin_credentials[user_idx][0] << endl;
                        cout << "Email: " << admin_credentials[user_idx][1] << endl;
                        cout << "\nPress (1. delete this admin,2. Main Menu): ";
                        choice = checked_input(1, 2, 43, 13);
                        if (choice == 1)
                        {
                            total_admins = admin_deletion(user_idx, total_admins);
                            update_credentials("admins.txt", admin_credentials, total_admins);
                        }
                        user_idx = -1;
                    }
                    else if (user_idx == -1)
                    {
                        cout << "Email Not Found: ";
                    }
                    else
                    {
                        cout << "admin1 cant be deleted...!";
                    }
                    a_choice = -1;
                }
                else if (a_choice == 9)
                {
                    int user_idx = -1;
                    SignUp_page();
                    gotoxy(28, 12);
                    cin >> credentials[0];
                    gotoxy(28, 15);
                    cin >> credentials[1];
                    gotoxy(28, 18);
                    cin >> credentials[2];
                    user_idx = input_scanner(credentials[1], total_buyers, total_admins);
                    if (user_idx != -1)
                    {
                        cout << "Email already exist...\n";
                        user_idx = -1;
                    }
                    else if (user_idx == -1)
                    {
                        register_credentials(credentials, 2, total_buyers);
                    }
                    else
                    {
                        cout << "Something went wrong";
                    }
                    a_choice = -1;
                }
                else if (a_choice == 10)
                {
                    int user_idx = -1;
                    cout << "Enter Email: ";
                    cin >> credentials[1];
                    user_idx = input_scanner(credentials[1], total_buyers, total_admins);
                    if ((user_idx != -1) && (user_idx != 0))
                    {
                        cout << "\nName: " << customer_credentials[user_idx][0] << endl;
                        cout << "Email: " << customer_credentials[user_idx][1] << endl;
                        cout << "\nPress (1. delete this customer,2. Main Menu): ";
                        choice = checked_input(1, 2, 45, 13);
                        if (choice == 1)
                        {
                            total_buyers = customer_deletion(user_idx, total_buyers);
                            update_credentials("customers.txt", customer_credentials, total_buyers);
                        }
                        user_idx = -1;
                    }
                    else if (user_idx == -1)
                    {
                        cout << "Email Not Found: ";
                    }
                    else
                    {
                        cout << "Customer 1 cant be deleted...!";
                    }
                    a_choice = -1;
                }
            }
            else if (user_type == 2)
            {
                if (b_choice == -1)
                {
                    buyer_Menu(user_index);
                    b_choice = checked_input(1, 6, 19, 16);
                }
                else if (b_choice == 1)
                {
                    print_our_services_start();
                    for (int i = last_service_no - 1, k = 1; i > -1; i--, k++)
                    {
                        cout << k << ". ";
                        display_service(services_records, i);
                    }
                    print_our_services_end();
                    b_choice = -1;
                }
                else if (b_choice == 2)
                {
                    if (order_placing == 0)
                    {
                        int y = 20;
                        print_order_type(y, services_records, last_service_no);
                        order_choice = checked_input(1, last_service_no, 27, y);
                        o_type = get_order_type(order_choice, services_records, last_service_no);
                    }
                    else if (order_placing == 1)
                    {
                        print_order_description();
                        cin.ignore();
                        getline(cin, o_description);
                    }
                    else if (order_placing == 2)
                    {
                        print_order_platform();
                        order_choice = checked_input(1, 4, 27, 15);
                        o_platform = get_order_platform(order_choice);
                    }
                    else if (order_placing == 3)
                    {
                        print_order_budget();
                        order_choice = checked_input(1, 5, 27, 16);
                        o_budget = get_order_budget(order_choice);
                    }
                    else if (order_placing == 4)
                    {
                        int start_date, start_month, start_year, completion_date, completion_month;
                        long int completion_year, start_day = 7, completion_day = 1; // intentionally put wrong input
                        print_order_Timeline();

                        for (int i = 0; (completion_day - start_day) < 3; i++)
                        {
                            if (i > 0)
                                cout << "\nMinimum interval must be 3 days.";

                            start_date = checked_input(1, 30, 20, 10);
                            start_month = checked_input(1, 12, 23, 10);
                            start_year = checked_input(2024, 2028, 26, 10);
                            completion_date = checked_input(1, 30, 25, 12);
                            completion_month = checked_input(1, 12, 28, 12);
                            completion_year = checked_input(2024, 2028, 31, 12);

                            start_day = (start_year * 365) + (start_month * 30) + (start_date);
                            completion_day = (completion_year * 365) + (completion_month * 30) + (completion_date);
                        }
                        cout << "\n                                      ";

                        o_time = get_order_date(start_date, start_month, start_year, completion_date, completion_month, completion_year);
                    }
                    else if (order_placing == 5)
                        print_order_submit_proposal();
                    else if (order_placing == 6)
                    {
                        print_order_submit_proposal();
                        cout << "\n\n\nCongradulations... \n\nYour request has been submitted\n\nPress any key to go to Main Menu";

                        order_records[last_order_no][2] = o_type;
                        order_records[last_order_no][6] = o_description;
                        order_records[last_order_no][4] = o_budget;
                        order_records[last_order_no][5] = o_time;
                        order_records[last_order_no][3] = o_platform;
                        order_records[last_order_no][0] = customer_credentials[user_index][1];
                        order_records[last_order_no][1] = "HXA_" + customer_credentials[user_index][1] + "_" + to_string(last_order_no + 1);
                        order_records[last_order_no][7] = "0";
                        last_order_no++;
                        update_data("orders.txt", order_records, last_order_no);
                    }
                    if (order_placing > -1 && order_placing < 6)
                    {
                        gotoxy(1, 30);
                        if (order_placing == 0)
                            cout << "Enter (1. Main Menu,2. next page): ";
                        else if (order_placing == 5)
                            cout << "Enter (1. previous page,2. submit): ";
                        else if (order_placing != 6)
                            cout << "Enter (1. previous page,2. next page): ";
                        nav = checked_input(1, 2, 39, 30);
                        if (nav == 2)
                            order_placing++;
                        else if (nav == 1)
                        {
                            if (order_placing > 0)
                                order_placing--;
                            else if (order_placing == 0)
                                b_choice = -1;
                        }
                    }
                    else
                    {
                        order_placing = 0;
                        b_choice = -1;
                    }
                }
                else if (b_choice == 3)
                {
                    for (int i = 0; i < last_order_no; i++)
                    {
                        if (customer_credentials[user_index][1] == order_records[i][0])
                        {
                            founded_order_indexes[total_found] = i;
                            total_found++;
                        }
                    }
                    print_order_book(founded_order_indexes, total_found);
                    b_choice = -1;
                }
                else if (b_choice == 5)
                {
                    if (r_choice == -1)
                    {
                        int review_y = 13;
                        // last_page_review = last_review-3;
                        print_reviews_header();
                        for (int i = last_review - 1; i > last_page_review; i--)
                            review_y = print_review(review_records, i, review_y);

                        print_review_Menu();
                        r_choice = checked_input(1, 3, 19, review_y + 3);
                    }
                    else if (r_choice == 2)
                    { // add review
                        int stars = 5;
                        string description = "";
                        print_add_reviews();
                        gotoxy(7, 13);
                        cout << customer_credentials[user_index][0];
                        gotoxy(21, 13);
                        cout << "November,19 2024";
                        stars = checked_input(1, 5, 29, 14);
                        cin.ignore();
                        gotoxy(24, 16);
                        getline(cin, description);

                        cout << "\nEnter (1. back,2. submit review): ";
                        choice = checked_input(1, 2, 34, 18);
                        if (choice == 2)
                        {
                            review_records[last_review][0] = customer_credentials[user_index][0];
                            review_records[last_review][1] = to_string(stars);
                            review_records[last_review][2] = "November,19 2024";
                            review_records[last_review][3] = description;
                            last_review++;
                            last_page_review++;
                            choice = -1;
                            update_data("reviews.txt", review_records, last_review);
                        }
                        r_choice = -1;
                    }
                    if (r_choice == 1)
                    {
                        b_choice = -1;
                        r_choice = -1;
                    }
                    if (r_choice == 3)
                    {
                        // if is used bcz its only processing and i dont want it to happen in seperate iteration
                        if (last_page_review > -1)
                        {
                            last_page_review--;
                        }
                        r_choice = -1;
                    }
                }
                else if (b_choice == 4)
                {
                    display_top_projects();
                    b_choice = -1;
                }
            }
            if ((b_choice == 6) || ((a_choice == 7) && (user_index != 0)) || ((a_choice == 11) && (user_index == 0)))
            {
                user_type = -1;
                b_choice = -1;
                a_choice = -1;
                choice = -1;
            }
        }
        getch();
        system("cls");
    }
    return 0;
}
//-----------------------user defined functions definition----------------------------
void update_data(string filename, string arr[][10], int &count)
{
    fstream file;
    file.open(filename, ios::out);
    file << "";
    file.close();
    file.open(filename, ios::app);
    for (int i = 0; i < count; i++)
    {
        if (i != 0)
            file << endl;
        for (int j = 0; j < 10; j++)
        {
            if (j != 0)
                file << ",";
            file << arr[i][j];
        }
    }

    file.close();
}
void get_data(string filename, string arr[][10], int &count)
{
    fstream file;
    string line = "\0";
    count = 0;
    file.open(filename, ios::in);
    while (getline(file, line))
    {
        for (int i = 0; i < 10; i++)
            arr[count][i] = getField(line, i + 1, ',');
        count++;
    }
    file.close();
}
void get_data(string filename, string arr[][4], int &count)
{
    fstream file;
    string line = "\0";
    count = 0;
    file.open(filename, ios::in);
    while (getline(file, line))
    {
        for (int i = 0; i < 4; i++)
            arr[count][i] = getField(line, i + 1, ';');
        count++;
    }
    file.close();
}
void update_data(string filename, string arr[][4], int &count)
{
    fstream file;
    file.open(filename, ios::out);
    file << "";
    file.close();
    file.open(filename, ios::app);
    for (int i = 0; i < count; i++)
    {
        if (i != 0)
            file << endl;
        for (int j = 0; j < 4; j++)
        {
            if (j != 0)
                file << ";";
            file << arr[i][j];
        }
    }
    file.close();
}
void update_credentials(string filename, string arr[][3], int &count)
{
    fstream file;
    file.open(filename, ios::out);
    file << "";
    file.close();
    file.open(filename, ios::app);
    for (int i = 0; i < count; i++)
        file << arr[count][0] << "," << arr[count][1] << "," << arr[count][2] << endl;
    file.close();
}

void register_credentials(string credentials[], int user_type, int &count)
{
    string filename;
    if (user_type == 1)
    {
        filename = "admins.txt";
        for (int i = 0; i < 3; i++)
            admin_credentials[count][i] = credentials[i];
    }
    else if (user_type == 2)
    {
        filename = "customers.txt";
        for (int i = 0; i < 3; i++)
            customer_credentials[count][i] = credentials[i];
    }
    fstream file;
    file.open(filename, ios::app);
    file << endl
         << credentials[0] << "," << credentials[1] << "," << credentials[2];
    file.close();
    count++;
}
void get_credentials(string filename, string credentials[][3], int &count)
{
    fstream file;
    string line;
    count = 0;
    file.open(filename, ios::in);
    while (getline(file, line))
    {
        for (int i = 0; i < 3; i++)
            credentials[count][i] = getField(line, i + 1, ',');
        count++;
    }
    file.close();
}
string getField(string data, int field_count, char seperator)
{
    int count = 1;
    string field;
    for (int i = 0; data[i] != '\0'; i++)
    {
        if (data[i] == seperator)
            count++;
        else if (field_count == count)
            field += data[i];
    }
    return field;
}
int calculate_Uncompleted_orders()
{
    int count = 0;
    for (int i = 0; i < last_order_no; i++)
    {
        if (order_records[i][7] != "1")
            count++;
    }
    return count;
}
bool order_fetcher(string customer, string orderer)
{
    if (customer == orderer)
        return true;
    return false;
}
string get_order_type(int order_choice, string services[][4], int last_service)
{
    for (int i = 0; i <= last_service; i++)
        if (order_choice == i)
            return services[i][0];
    if (order_choice == last_service + 1)
        return "auto";
}

string get_order_platform(int order_choice)
{
    if (order_choice == 1)
        return "Web";
    else if (order_choice == 2)
        return "Mobile";
    else if (order_choice == 3)
        return "Desktop";
    else if (order_choice == 4)
        return "Cross-platform";
}
string get_order_budget(int order_choice)
{
    if (order_choice == 1)
        return "<$5,000";
    else if (order_choice == 2)
        return "$5,000 - $10,000";
    else if (order_choice == 3)
        return "$10,000 - $20,000";
    else if (order_choice == 4)
        return "$20,000 - $50,000";
    else if (order_choice == 5)
        return ">$50,000";
}
string get_order_date(int start_date, int start_month, int start_year, int completion_date, int completion_month, int completion_year)
{
    return to_string(start_date) + "/" + to_string(start_month) + "/" + to_string(start_year) + " to " + to_string(completion_date) + "/" + to_string(completion_month) + "/" + to_string(completion_year);
}

int email_authenticator(string email, string password, int total_admins, int total_customer)
{

    for (int j = 0; j < total_admins; j++)
    {
        if (admin_credentials[j][1] == email && admin_credentials[j][2] == password)
        {
            user_type = 1;
            return j;
        }
    }
    for (int j = 0; j < total_customer; j++)
    {
        if (customer_credentials[j][1] == email && customer_credentials[j][2] == password)
        {
            user_type = 2;
            return j;
        }
    }
    return -1;
}
int input_scanner(string email, int total_buyers, int total_admins)
{
    int i = 0;
    while (i < 2)
    {
        if (i == 0)
        {
            for (int j = 0; j < total_admins; j++)
            {
                if (admin_credentials[j][1] == email)
                {
                    if (user_type == -1)
                        user_type = 1;
                    return j;
                }
            }
        }

        else if (i == 1)
        {
            for (int j = 0; j < total_buyers; j++)
            {
                if (customer_credentials[j][1] == email)
                {
                    if (user_type == -1)
                        user_type = 2;
                    return j;
                }
            }
        }
        i++;
    }
    return -1;
}
int calculate_total_revenue()
{
    int revenue = 0;
    for (int i = 0; i < last_order_no; i++)
    {
        if (order_records[i][7] == "1")
            revenue += stoi(order_records[i][8]);
    }
    return revenue;
}
int calculate_completed_orders()
{
    int count = 0;
    for (int i = 0; i < last_order_no; i++)
    {
        if (order_records[i][7] == "1")
        {
            count++;
        }
    }
    return count;
}

string calculate_most_frequent_element(string array[][10], int col, int size)
{
    int max_count = 0;
    string most_frequent = "None";

    for (int i = 0; i < size; i++)
    {
        int count = 0;
        for (int j = 0; j < size; j++)
        {
            if (array[i][col] == array[j][col])
            {
                count++;
            }
        }
        if (count > max_count)
        {
            max_count = count;
            most_frequent = array[i][col];
        }
    }
    return most_frequent;
}

int admin_deletion(int index, int total_admins)
{
    if (index != 0)
    {
        total_admins--;
        admin_credentials[index][0] = admin_credentials[total_admins][0];
        admin_credentials[index][1] = admin_credentials[total_admins][1];
        admin_credentials[index][2] = admin_credentials[total_admins][2];
        return total_admins;
    }
}
int customer_deletion(int index, int total_buyers)
{
    total_buyers--;
    customer_credentials[index][0] = customer_credentials[total_buyers][0];
    customer_credentials[index][1] = customer_credentials[total_buyers][1];
    customer_credentials[index][2] = customer_credentials[total_buyers][2];
    return total_buyers;
}
int checked_input(int interval_start, int interval_end, int x, int y)
{
    int var;
    gotoxy(x, y);
    cin >> var;
    while ((var < interval_start) || (var > interval_end))
    {
        gotoxy(1, y + 1);
        cout << "Wrong input...";
        gotoxy(x, y);
        cin >> var;
        cin.ignore();
    }
    gotoxy(1, y + 1);
    cout << "              ";
    gotoxy(0, y + 1);
    return var;
}
string sales_string_auto_manual_handler(string auto_value, string manual_value)
{
    if (manual_value == "auto")
        return auto_value;
    return manual_value;
}
string calculate_order_status(int index)
{
    if (order_records[index][7] == "1")
        return "completed";
    return "Uncompleted";
}
bool email_validation(string email)
{
    int rate_idx = -1, dot_idx = -1;
    int email_len = 0;
    for (int i = 0; email[i] != '\0'; i++)
    {
        if (email[i] == ' ')
            return false;
        email_len++;
    }
    if (email_len < 5)
        return false;
    for (int i = 0; i < email_len; i++)
    {
        if (email[i] == '@')
        {
            if (rate_idx != -1)
                return false;
            rate_idx = i;
        }
        else if (email[i] == '.')
            dot_idx = i;
    }
    if (((rate_idx == -1) || (dot_idx == -1)) || ((rate_idx == 0) || (rate_idx > dot_idx - 2)) || (dot_idx == email_len - 1))
        return false;
    return true;
}
bool password_validation(string password)
{
    bool special_idx = false, num_idx = false, letter_index = false;
    int password_len = 0;
    char a;
    for (int i = 0; password[i] != '\0'; i++)
    {
        if (password[i] == ' ')
            return false;
        password_len++;
    }
    if (password_len < 8 || password_len > 16)
        return false;
    for (int i = 0; i < password_len; i++)
    {
        a = password[i];
        if ((a > 64 && a < 91) || (a > 96 && a < 123))
            letter_index = true;
        if (a > 47 && a < 58)
            num_idx = true;
        else if ((a >= 33 && a <= 47) || (a >= 58 && a <= 64) || (a >= 91 && a <= 96) || (a >= 123 && a <= 126))
            special_idx = true;
    }
    if (special_idx && num_idx && letter_index)
        return true;
    return false;
}
void print_sentence(string sentence, int lenght)
{
    int len = 0;
    for (int i = 0; sentence[i] != '\0'; i++)
    {
        cout << sentence[i];
        len++;
        if ((len >= lenght - 4) && (sentence[i] == ' '))
        {
            cout << "\n\t";
            len = 0;
        }
    }
}
int print_review(string reviews[][4], int review_idx, int review_y)
{
    int review_x = 0;
    cout << "     --------------------------------------------------------------------------------------\n";
    cout << "     |             |                                                                      |\n";
    cout << "     |                                                                                    |\n";
    cout << "     |                                                                                    |\n";
    cout << "     |                                                                                    |\n";
    cout << "     |                                                                                    |\n";
    cout << "     |                                                                                    |\n";
    cout << "     --------------------------------------------------------------------------------------\n";

    gotoxy(review_x + 7, review_y + 1);
    for (int i = 0; i < stoi(reviews[review_idx][1]); i++)
    {
        cout << "@ ";
    }
    gotoxy(review_x + 22, review_y + 1);
    cout << reviews[review_idx][2];
    gotoxy(review_x + 7, review_y + 3);
    cout << reviews[review_idx][0];
    gotoxy(review_x + 7, review_y + 4);
    int y_addition = 3;

    print_sentence(reviews[review_idx][3], 80);

    review_y += 9;
    gotoxy(review_x, review_y);
    return review_y;
}
int search_services(string services[][4], int last_service_no)
{
    string s_type;
    cout << "Enter service type to search: ";
    cin.ignore();
    getline(cin, s_type);
    for (int i = 0; i < last_service_no; i++)
    {
        if (services[i][0] == s_type)
            return i;
    }
    return -1;
}
void print_admin_dashboard(int completed_order, int revenue, string popular_service, string new_order, string feedback)
{
    cout << "1. Order Overview\n";
    cout << "\tTotal Orders: " << last_order_no << " | Pending: " << last_order_no - completed_order << " | Completed : " << completed_order << endl;
    cout << "\n\n2. Sales Analytics\n";
    cout << "\tTotal Revenue: $" << revenue << endl;
    cout << "\tPopular Service: " << popular_service << endl;
    cout << "\n\n3. Recent Top Projects\n";
    for (int i = 0; i < last_order_no; i++)
    {
        if (order_records[i][9] != "\0")
            cout << "\t" << order_records[i][9] << " ($" << order_records[i][8] << ")\n";
    }
    cout << "\n\n4. Notifications\n";
    cout << "\tNew Order: " << new_order << endl;
    cout << "\tFeedBack: \n\t";
    print_sentence(feedback, 40);
    cout << "\n\n5. Quick actions\nGoto (1. Veiw Orders,2. Add Projects,3. Veiw Analytics,4. Main Menu): ";
}
void display_service(string services_arr[][4], int ser_idx)
{
    cout << services_arr[ser_idx][0] << endl;
    cout << "\tDescription: ";
    int lenght = 0;

    print_sentence(services_arr[ser_idx][1], 80);

    cout << endl;
    if (services_arr[ser_idx][2] != "\0")
        cout << "\tTechnologies: " << services_arr[ser_idx][2] << endl;

    cout << "\tServices: " << services_arr[ser_idx][3] << endl;
}
int search_order_by_id(string id)
{
    int index = -1;
    for (int i = 0; i < last_order_no; i++)
    {
        if (order_records[i][1] == id)
            index = i;
    }
    return index;
}
string display_order(int index)
{
    string order_to_display = "Type: ";
    order_to_display += order_records[index][2];
    order_to_display += "\nId: " + order_records[index][1];
    order_to_display += "\nDescription: " + order_records[index][6];
    order_to_display += "\nBudget: " + order_records[index][4];
    order_to_display += "\nStatus: ";

    if (order_records[index][7] == "1")
    {
        order_to_display += "Completed\n";
        order_to_display += "Revenue: $" + order_records[index][8] + "\n";
    }
    else
        order_to_display += "Uncompleted\n";

    return order_to_display;
}
void print_search_order_email()
{
    cout << "================================================================================================\n";
    cout << "                                 ORDER MANAGEMENT: Search Orders\n";
    cout << "================================================================================================\n\n";
    cout << "Enter customer Email to find their Orders: ";
}
void delete_order()
{
    cout << "================================================================================================\n";
    cout << "                                 ORDER MANAGEMENT: Delete Order\n";
    cout << "================================================================================================\n\n";
    cout << "Enter Order ID to Delete: ";
}

void print_update_order_status()
{
    // string id;
    // int index = -1,revenue;
    // bool status= false;
    cout << "================================================================================================\n";
    cout << "                                 ORDER MANAGEMENT: Update Status\n";
    cout << "================================================================================================\n\n";
    cout << "Enter Order ID to Update Status: ";
    // cin>>id;
    // index = search_order_by_id(id);
    // if(index == -1)
    //     cout<<"Not Found...!\n";
    // else{
    // cout<<"\nCurrent Status: ";
    // if(order_status[index])
    //     cout<<"completed";
    // else
    //     cout<<"Uncompleted";
    // cout<<"\nMark as (1. Completed, 2. Uncompleted): ";
    // status = checked_input(1,2,40,15);
    // if(status == 1){
    //     cout<<"\nAdd Order Revenue: $";
    //     revenue = checked_input(10,100000,20,17);
    //     order_revenue[index] = revenue;
    //     order_status[index] = status;

    // }
    // cout<<"\nStatus Updated Successfully!\n";
    // }
    //     gotoxy(0,20);
    // cout<<"================================================================================================\n\n";
}

void generate_order_summary()
{
    int j = 0;
    cout << "===============================================================================================\n";
    cout << "                                 ORDER MANAGEMENT: Summary\n";
    cout << "===============================================================================================\n\n";
    cout << "Total Orders: " << last_order_no << endl
         << endl;
    for (int i = 0; i < last_order_no; i++)
    {
        if (order_records[i][7] == "1")
            j++;
    }
    cout << "Completed Orders: " << j << endl
         << endl;
    j = 0;
    for (int i = 0; i < last_order_no; i++)
    {
        if (order_records[i][7] == "0")
            j++;
    }
    cout << "Uncompleted Orders: " << j << endl
         << endl;
    cout << "===============================================================================================\n\n";
    cout << "Press any key to go back...";
}
void print_all_orders()
{
    cout << "===============================================================================================\n";
    cout << "                                 ORDER MANAGEMENT: All Orders\n";
    cout << "===============================================================================================\n\n";

    cout << " Order ID                 | Customer Email         | Type                      | Status\n";
    cout << "-----------------------------------------------------------------------------------------------\n";
    for (int i = last_order_no - 1, x = 1, y = 15; i >= 0; i--, y++)
    {
        gotoxy(x, y);
        cout << order_records[i][1];
        gotoxy(x + 25, y);
        cout << "| ";
        cout << order_records[i][0];
        gotoxy(x + 50, y);
        cout << "| " << order_records[i][2];
        gotoxy(x + 78, y);
        cout << "| ";
        if (order_records[i][7] == "0")
            cout << "Uncompleted";
        else
            cout << "Completed";
    }
    cout << "\n\n================================================================================================\n\n";
    cout << "Press any key to go back...";
}

void print_order_book(int order_indexes[], int total_orders)
{
    bool found = false;
    cout << "                                       ORDER BOOK\n\n";
    cout << "================================================================================================\n";
    cout << "                                    Uncompleted Orders\n";
    cout << "================================================================================================\n\n";
    for (int i = 0, j = 0, k = 1; i < total_orders; i++)
    {
        j = order_indexes[i];
        if (order_records[j][7] == "0")
        {
            cout << "Order # " << k << endl;
            cout << "\t* Service Type: " << order_records[j][2] << endl;
            cout << "\t* Description: " << order_records[j][6] << endl;
            cout << "\t* Platform: " << order_records[j][3] << endl;
            cout << "\t* Proposal Budget: " << order_records[j][4] << endl;
            cout << "\t* Timeline: " << order_records[j][5] << endl;
            cout << "\t* Status: In Progress" << endl;
            k++;
            found = true;
        }
    }
    if (!found)
    {
        cout << "No Record\n";
    }
    found = false;
    cout << "\n================================================================================================\n";
    cout << "                                     Completed Orders\n";
    cout << "================================================================================================\n\n";
    for (int i = 0, j = 0, k = 1; i < total_orders; i++)
    {
        j = order_indexes[i];
        if (order_records[j][7] == "1")
        {
            cout << "Order # " << k << endl;
            cout << "\t* Service Type: " << order_records[j][2] << endl;
            cout << "\t* Description: " << order_records[j][6] << endl;
            cout << "\t* Platform: " << order_records[j][3] << endl;
            cout << "\t* Proposal Budget: " << order_records[j][4] << endl;
            cout << "\t* Completed Price: $" << order_records[j][8] << endl;
            cout << "\t* Timeline: " << order_records[j][5] << endl;
            cout << "\t* Status: Completed" << endl;
            k++;
            found = true;
        }
    }
    if (!found)
    {
        cout << "No Record\n\n";
    }
    cout << "\nPress any Key to go to Main Menu\n";
}
void display_top_projects()
{
    int count = 1;
    for (int i = 0; i < last_order_no; i++)
    {
        if (order_records[i][9] != "\0")
        {
            if (count == 1)
                cout << "\n------------------------------------------------------------------------------------------------\n\n";
            cout << endl
                 << count << "* Project Name: " << order_records[i][9] << "\n\tType: " << order_records[i][2] << "\n\tDescription: " << order_records[i][6] << "\n\tBudget: $" << order_records[i][8] << endl;
            cout << "\n------------------------------------------------------------------------------------------------\n";
            count++;
        }
    }
    if (count == 1)
        cout << "No Top Projects Yet...!\n";
    cout << "Press any key to go back.";
}

void print_review_Menu()
{
    cout << "1. main Menu.\n";
    cout << "2. Add review.\n";
    cout << "3.Load more.\n";
    cout << "Enter your choice: ";
}

void print_order_type(int &y, string services[][4], int last_service)
{
    cout << "Place Your Order\n";
    cout << "At HXA Software Lab, we make it easy to bring your vision to life! Complete the form below to\n";
    cout << "request our services. Our team will review your details and reach out shortly to discuss your\n";
    cout << "project requirements.\n";
    cout << "\n";
    cout << "Order Form\n";
    cout << "1. Select Service Type:\n";
    cout << "\n";
    cout << "Please select the primary service you are interested in:\n";

    gotoxy(0, y);
    for (int i = 0; i < last_service; i++)
    {
        cout << "\t" << i + 1 << ". " << services[i][0] << endl;
        y++;
    }
    cout << "\tEnter your choice: ";
}
void print_order_description()
{
    cout << "2. Project Description:\n\n";
    cout << "\tDescribe your project or specific needs:\n";
}
void print_order_platform()
{
    cout << "3. Preferred Platform:\n\n";
    cout << "Select the platform(s) for the project (if applicable):\n";
    cout << "\t1. Web\n";
    cout << "\t2. Mobile (Android, iOS)\n";
    cout << "\t3. Desktop\n";
    cout << "\t4. Cross-platform\n";
    cout << "\tEnter your choice: ";
}
void print_order_budget()
{
    cout << "4. Project Budget:\n\n";
    cout << "Please specify your estimated budget range:\n";
    cout << "\t1. <$5,000\n";
    cout << "\t2. $5,000 - $10,000\n";
    cout << "\t3. $10,000 - $20,000\n";
    cout << "\t4. $20,000 - $50,000\n";
    cout << "\t5. >$50,000\n";
    cout << "\tEnter your choice: ";
}
void print_order_Timeline()
{
    cout << "5. Timeline:\n";
    cout << "When would you like to start, and when is the expected completion date?\n";
    cout << "\tStart Date: ";
    cout << "\n\n\tCompletion Date: ";
}
void print_order_submit_proposal()
{
    cout << "                           Submit Your Order\n";
    cout << "You've completed the form, click '1' to send us your project request.Our\n";
    cout << "team will contact you to confirm details, discuss your project scope, and provide\n";
    cout << "a customized proposal.\n";
}

void print_add_sales_analytics(int x, int y, string services[][4], int col, int last_service)
{
    cout << "================================================================================================\n";
    cout << "                                        SALES ANALYTICS\n";
    cout << "================================================================================================\n\n";
    cout << "1. Adjust Total Revenue:\n\n";
    cout << "2. Most Popular Service:\n\n";
    cout << "3. Adjust Total Completed Orders:\n\n";
    cout << "4. Search Email to Mark as Top Customer:\n\n";
    // cout<<"================================================================================================\n";
    // cout<<"                                        SALES ANALYTICS\n";
    // cout<<"================================================================================================\n\n";
    // cout<<"1. Adjust Total Revenue:                                       /  1. Custom Software Development\n";
    // cout<<"                                                               |  2. Web Development\n";
    // cout<<"2. Most Popular Service:                       ----------------|  3. Mobile App Development\n";
    // cout<<"                                                               |  4. UI/UX Design\n";
    // cout<<"3. Adjust Total Completed Orders:                              |  5. Data Analytics\n";
    // cout<<"                                                               |  6. Quality Assurance & Testing\n";
    // cout<<"4. Search Email to Mark as Top Customer:                       |  7. IT Consulting and Support\n";
    // cout<<"                                                               \\  8. Auto Calculate\n";
    for (int i = 0; i < last_service; i++)
    {
        if (i == 2)
        {
            gotoxy(47, y + i);
            cout << "----------------";
        }
        gotoxy(63, y + i);
        if (i == 0)
            cout << "/ ";
        else
            cout << "| ";
        cout << i + 1 << ". " << services[i][col];
    }
    gotoxy(63, y + last_service + 1);
    cout << "\\ " << last_service + 1 << ". Auto calculate";
}
void print_sales_analytics(int revenue, string popular_service, string top_customer, int completed_orders, int avg_budget)
{
    cout << "================================================================================================\n";
    cout << "                                        SALES ANALYTICS\n";
    cout << "================================================================================================\n\n";
    cout << "1. Total Revenue: " << revenue << endl
         << endl;
    cout << "2. Most Popular Service: " << popular_service << endl
         << endl;
    cout << "3. Top Customer: " << top_customer << endl
         << endl;
    cout << "3. Completed Orders: " << completed_orders << endl
         << endl;
    cout << "5. Average Budget per Project: " << avg_budget << endl
         << endl;
}
void manage_sales_menu()
{
    cout << "================================================================================================\n";
    cout << "                                        SALES ANALYTICS\n";
    cout << "================================================================================================\n\n";
    cout << "1. Veiw Sales Analytics\n";
    cout << "2. Edit Sales Analytics(Offline customers)\n";
    cout << "3. Back to Main Menu\n";
    cout << "Enter your choice:";
}
void top_projects_menu()
{
    cout << "================================================================================================\n";
    cout << "                                       TOP PROJECTS\n";
    cout << "================================================================================================\n\n";
    cout << "1. Veiw Top Projects\n";
    cout << "2. Edit Top Project\n";
    cout << "3. Back to Main Menu\n";
    cout << "Enter your choice:";
}

void manage_order_Menu()
{
    cout << "================================================================================================\n";
    cout << "                                       ORDER MANAGEMENT\n";
    cout << "================================================================================================\n\n";
    cout << "1. View All Orders\n";
    cout << "2. Update Order Status\n";
    cout << "3. Delete an Order\n";
    cout << "4. Search Orders\n";
    cout << "5. Generate Summary Reports\n";
    cout << "6. Back to Main Menu\n";
    cout << "Enter your choice:";
}

void manage_services_Menu()
{
    cout << "    MANAGE SERVICES\n";
    cout << "1. Main Menu\n";
    cout << "2. Display services.\n";
    cout << "3. Add services.\n";
    cout << "4. Delete services.\n";
    cout << "5. Replace Services.\n";
    cout << "Enter your choice:";
}

void main_admin_Menu(int user_index)
{
    cout << "Hello " << admin_credentials[user_index][0] << endl;
    cout << "\t\tMENU\n";
    cout << "1. Admin Dashboard\n";
    cout << "2. Order Management\n";
    cout << "3. Manage Services\n";
    cout << "4. Manage Sales Analytics\n";
    cout << "5. Add Recent Top Projects\n";
    cout << "6. Client Reviews.\n";
    cout << "7. Add New Admin Profile.\n";
    cout << "8. Delete Admin Profile.\n";
    cout << "9. Add New Customer Profile.\n";
    cout << "10. Delete Customer Profile.\n";
    cout << "11. SignOut.\n";
    cout << "Enter your choice: ";
}
void admin_Menu(int user_index)
{
    cout << "Hello " << admin_credentials[user_index][0] << endl;
    cout << "\t\tMENU\n";
    cout << "1. Admin Dashboard\n";
    cout << "2. Order Management\n";
    cout << "3. Manage Services\n";
    cout << "4. Manage Sales Analytics\n";
    cout << "5. Add Recent Top Projects\n";
    cout << "6. Client Reviews.\n";
    cout << "7. SignOut.\n";
    cout << "Enter your choice: ";
}

void buyer_Menu(int user_index)
{
    cout << "Hello " << customer_credentials[user_index][0] << endl;
    cout << "\t\tMENU\n";
    cout << "1. Our Services.\n";
    cout << "2. Place Order.\n";
    cout << "3. Order Book.\n";
    cout << "4. Our Recent Top Projects.\n";
    cout << "5. Client Reviews.\n";
    cout << "6. SignOut.\n";
    cout << "Enter your choice: ";
}
void entry_Menu()
{
    cout << "Welcome to HXA Software LAB\n";
    cout << "\t\tMENU\n";
    cout << "1. Our Services.\n";
    cout << "2. Place Order.\n";
    cout << "3. Log In.\n";
    cout << "4. Sign Up.\n";
    cout << "5. Exit.\n";
    cout << "Enter your choice: ";
}

void print_add_reviews()
{
    cout << "     ----------------------------------------------------------------------------------------\n";
    cout << "     |                                        Add Reviews                                   |\n";
    cout << "     |                             give your guidance to our customer                       |\n";
    cout << "     ----------------------------------------------------------------------------------------\n\n";
    cout << "                   |\n";
    cout << "       No. of Stars(1 to 5): \n\n       Add your Review: ";
}

void print_reviews_header()
{
    cout << "     ----------------------------------------------------------------------------------------\n";
    cout << "     |                                      Client Reviews                                  |\n";
    cout << "     |                             See what our clients have to say!                        |\n";
    cout << "     ----------------------------------------------------------------------------------------\n\n";
}
void print_our_services_start()
{
    cout << "                                    ---OUR SERVICES---\n";
    cout << "                                   \n";
    cout << "Welcome to HXA Software Lab, where we bring your digital ideas to life! We offer a range of\n";
    cout << "professional services tailored to meet the unique needs of each client. Our team is committed to\n";
    cout << "delivering innovative solutions with a focus on quality, efficiency, and support.\n";
    cout << "\n";
}
void print_our_services_end()
{
    cout << "\n";
    cout << "At HXA Software Lab, we are committed to helping you achieve your goals with solutions that are\n";
    cout << "tailored to your business needs. Whether you're looking to build a new product, optimize existing\n";
    cout << "processes, or improve your digital footprint, we're here to support you every step of the way.\n";
}

void login_page()
{
    cout << "\t\t\t/------------------------------------------------\\\n";
    cout << "\t\t\t|                     LOGIN                      |\n";
    cout << "\t\t\t|------------------------------------------------|\n";
    cout << "\t\t\t|   EMAIL:                                       |\n";
    cout << "\t\t\t|                                                |\n";
    cout << "\t\t\t|------------------------------------------------|\n";
    cout << "\t\t\t|   PASSWORD:                                    |\n";
    cout << "\t\t\t|                                                |\n";
    cout << "\t\t\t\\------------------------------------------------/\n";
}
void SignUp_page()
{
    cout << "\t\t\t/------------------------------------------------\\\n";
    cout << "\t\t\t|                    SIGN UP                     |\n";
    cout << "\t\t\t|------------------------------------------------|\n";
    cout << "\t\t\t|   USERNAME:                                    |\n";
    cout << "\t\t\t|                                                |\n";
    cout << "\t\t\t|------------------------------------------------|\n";
    cout << "\t\t\t|   EMAIL:                                       |\n";
    cout << "\t\t\t|                                                |\n";
    cout << "\t\t\t|------------------------------------------------|\n";
    cout << "\t\t\t|   PASSWORD:                                    |\n";
    cout << "\t\t\t|                                                |\n";
    cout << "\t\t\t\\------------------------------------------------/\n";
}

void print_header()
{
    cout << " __________________________________________________________________________________________________ " << endl;
    cout << "|                                 __________                                                       |" << endl;
    cout << "|                                |          |                                                      |" << endl;
    cout << "|                                |__________|   HXA  SOFTWARE  LAB                                 |" << endl;
    cout << "|                               /____________\\                                                     |" << endl;
    cout << "|__________________________________________________________________________________________________|\n\n"<< endl;
}
void intro()
{
    cout << "                                                   ###   ##   ##   ##   #####                                               \n";
    Sleep(40);
    cout << "                                                    ##   ##   ##   ##  ##   ##                                              \n";
    Sleep(40);
    cout << "                                                    ##   ##    ## ##   ##   ##                                              \n";
    Sleep(40);
    cout << "                                                    #######     ###    #######                                              \n";
    Sleep(40);
    cout << "         _____________________________              ##   ##    ## ##   ##   ##                                              \n";
    Sleep(40);
    cout << "        /                             \\             ##   ##   ##   ##  ##   ##                                              \n";
    Sleep(40);
    cout << "       |                               |            ##   ###  ##   ##  ##   ##                                              \n";
    Sleep(40);
    cout << "       |                               |                                                                                    \n";
    Sleep(40);
    cout << "       |                               |                                                                                    \n";
    Sleep(40);
    cout << "       |                               |            #####     #####   #######  ######  ##    ##    #####   ######    #######\n";
    Sleep(40);
    cout << "       |                               |           ##   ##   ##   ##   ##  ##    ##    ##    ##   ##   ##   ##  ##    ##  ##\n";
    Sleep(40);
    cout << "       |                               |           ##        ##   ##   ##        ##    ##    ##   ##   ##   ##  ##    ##    \n";
    Sleep(40);
    cout << "       |                               |            #####    ##   ##   ####      ##    ## ## ##   #######   #####     ####  \n";
    Sleep(40);
    cout << "       |                               |                ##   ##   ##   ##        ##    ########   ##   ##   ###       ##    \n";
    Sleep(40);
    cout << "       |_______________________________|           ##   ##   ##   ##   ##        ##    ###  ###   ##   ##   ## ##     ##  ##\n";
    Sleep(40);
    cout << "       /                               \\            #####     #####   ####       ##    ##    ##   ##   ##   ##  ###  #######\n";
    Sleep(40);
    cout << "      /                                 \\                                                                                   \n";
    Sleep(40);
    cout << "     /                                   \\                                                                                  \n";
    Sleep(40);
    cout << "    /                                     \\        ##        #####   ######                                                 \n";
    Sleep(40);
    cout << "   /                                       \\       ##       ##   ##   ##  ##                                                \n";
    Sleep(40);
    ;
    cout << "   \\_______________________________________/       ##       ##   ##   ##  ##                                                \n";
    Sleep(40);
    cout << "                                                   ##       #######   #####                                                 \n";
    Sleep(40);
    cout << "                                                   ##       ##   ##   ##  ##                                                \n";
    Sleep(40);
    cout << "                                                   ##       ##   ##   ##  ##                                                \n";
    Sleep(40);
    cout << "                                                   #######  ##   ##  ######                                                 " << endl;
    Sleep(1000);
}
void gotoxy(int x, int y)
{

    COORD coordinates;
    coordinates.X = x;
    coordinates.Y = y;
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), coordinates);
}