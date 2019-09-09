using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FGPay.Manager.Migrations
{
    public partial class BaseData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agent",
                columns: table => new
                {
                    AgentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgentUserID = table.Column<string>(maxLength: 20, nullable: false),
                    AgentFullName = table.Column<string>(maxLength: 50, nullable: false),
                    Balance = table.Column<decimal>(type: "money", nullable: false),
                    BankFullName = table.Column<string>(maxLength: 50, nullable: true),
                    AccountName = table.Column<string>(maxLength: 50, nullable: true),
                    AccountCardNumber = table.Column<string>(maxLength: 20, nullable: true),
                    Remark = table.Column<string>(maxLength: 100, nullable: true),
                    AgentState = table.Column<byte>(type: "tinyint", nullable: false),
                    Operator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: false),
                    LastLoginTime = table.Column<DateTime>(nullable: false),
                    ClientIP = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agent", x => x.AgentID);
                });

            migrationBuilder.CreateTable(
                name: "AgentCreditLog",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(50)", nullable: false),
                    AgentUserID = table.Column<string>(maxLength: 20, nullable: false),
                    MerchantUserID = table.Column<string>(maxLength: 20, nullable: false),
                    CreditLogType = table.Column<byte>(type: "tinyint", nullable: false),
                    BeforeCredit = table.Column<decimal>(type: "money", nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    OrderNumber = table.Column<string>(maxLength: 20, nullable: true),
                    Remark = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentCreditLog", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AgentOrder",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(50)", nullable: false),
                    OrderNo = table.Column<string>(maxLength: 50, nullable: false),
                    AgentUserID = table.Column<string>(maxLength: 20, nullable: false),
                    AgentFullName = table.Column<string>(maxLength: 50, nullable: false),
                    BankFullName = table.Column<string>(maxLength: 50, nullable: false),
                    AccountName = table.Column<string>(maxLength: 50, nullable: false),
                    AccountCardNumber = table.Column<string>(maxLength: 20, nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    WithdrawalFee = table.Column<decimal>(type: "money", nullable: false),
                    ExtraRemark = table.Column<string>(maxLength: 50, nullable: true),
                    Remark = table.Column<string>(maxLength: 50, nullable: true),
                    State = table.Column<byte>(type: "tinyint", nullable: false),
                    Operator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: false),
                    ClientIP = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentOrder", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BankFullName = table.Column<string>(maxLength: 50, nullable: false),
                    AccountName = table.Column<string>(maxLength: 50, nullable: false),
                    AccountCardNumber = table.Column<string>(maxLength: 20, nullable: false),
                    State = table.Column<byte>(type: "tinyint", nullable: false),
                    Operator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MerchantCreditLog",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(50)", nullable: false),
                    MerchantUserID = table.Column<string>(maxLength: 20, nullable: false),
                    CreditLogType = table.Column<byte>(type: "tinyint", nullable: false),
                    BeforeCredit = table.Column<decimal>(type: "money", nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    OrderNumber = table.Column<string>(maxLength: 20, nullable: true),
                    Remark = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantCreditLog", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MerchantOrder",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(50)", nullable: false),
                    OrderNo = table.Column<string>(maxLength: 50, nullable: false),
                    MerchantOrderNo = table.Column<string>(maxLength: 50, nullable: false),
                    AgentUserID = table.Column<string>(maxLength: 20, nullable: true),
                    AgentFullName = table.Column<string>(maxLength: 50, nullable: true),
                    MerchantUserID = table.Column<string>(maxLength: 20, nullable: false),
                    MerchantFullName = table.Column<string>(maxLength: 50, nullable: false),
                    BankFullName = table.Column<string>(maxLength: 50, nullable: false),
                    AccountName = table.Column<string>(maxLength: 50, nullable: false),
                    AccountCardNumber = table.Column<string>(maxLength: 20, nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    WithdrawalFee = table.Column<decimal>(type: "money", nullable: false),
                    ExtraRemark = table.Column<string>(maxLength: 50, nullable: true),
                    Remark = table.Column<string>(maxLength: 50, nullable: true),
                    State = table.Column<byte>(type: "tinyint", nullable: false),
                    SyncCallbackUrl = table.Column<string>(maxLength: 50, nullable: true),
                    AyncCallbackUrl = table.Column<string>(maxLength: 50, nullable: true),
                    Operator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: false),
                    ClientIP = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantOrder", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentChannel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PaymentType = table.Column<byte>(type: "tinyint", nullable: false),
                    ChannelName = table.Column<string>(maxLength: 50, nullable: false),
                    MinLimitSingle = table.Column<decimal>(type: "money", nullable: false),
                    MaxLimitSingle = table.Column<decimal>(type: "money", nullable: false),
                    MaxLimitDaily = table.Column<decimal>(type: "money", nullable: false),
                    ChannelState = table.Column<byte>(type: "tinyint", nullable: false),
                    Operator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentChannel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "QRCode",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodeInformation = table.Column<string>(maxLength: 50, nullable: true),
                    URL = table.Column<string>(maxLength: 200, nullable: false),
                    UserID = table.Column<string>(maxLength: 50, nullable: false),
                    UserName = table.Column<string>(maxLength: 20, nullable: true),
                    PaymentType = table.Column<int>(nullable: false),
                    State = table.Column<byte>(type: "tinyint", nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: false),
                    Operator = table.Column<string>(maxLength: 50, nullable: true),
                    ClientIP = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QRCode", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptOrder",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(50)", nullable: false),
                    OrderNo = table.Column<string>(maxLength: 50, nullable: false),
                    MerchantOrderNo = table.Column<string>(maxLength: 50, nullable: false),
                    AgentUserID = table.Column<string>(maxLength: 20, nullable: true),
                    AgentFullName = table.Column<string>(maxLength: 50, nullable: true),
                    MerchantUserID = table.Column<string>(maxLength: 20, nullable: false),
                    MerchantFullName = table.Column<string>(maxLength: 50, nullable: false),
                    PaymentType = table.Column<int>(nullable: false),
                    QRAccountUserID = table.Column<string>(maxLength: 50, nullable: false),
                    AccountUserID = table.Column<string>(maxLength: 50, nullable: false),
                    AccountName = table.Column<string>(maxLength: 20, nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    ExtraRemark = table.Column<string>(maxLength: 50, nullable: true),
                    Remark = table.Column<string>(maxLength: 50, nullable: true),
                    State = table.Column<byte>(type: "tinyint", nullable: false),
                    SyncCallbackUrl = table.Column<string>(maxLength: 50, nullable: true),
                    AyncCallbackUrl = table.Column<string>(maxLength: 50, nullable: true),
                    Operator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: false),
                    ClientIP = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptOrder", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RepAccount",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<string>(maxLength: 50, nullable: false),
                    UpperLevel = table.Column<string>(maxLength: 50, nullable: true),
                    LoginPwd = table.Column<string>(maxLength: 50, nullable: false),
                    WithdrawalPwd = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: false),
                    FullName = table.Column<string>(maxLength: 20, nullable: false),
                    BankFullName = table.Column<string>(maxLength: 50, nullable: false),
                    AccountName = table.Column<string>(maxLength: 20, nullable: false),
                    AccountCardNumber = table.Column<string>(maxLength: 20, nullable: false),
                    Operator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: false),
                    ClientIP = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepAccount", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RepAccountDepositOrder",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    UserID = table.Column<string>(maxLength: 50, nullable: false),
                    OrderNo = table.Column<string>(maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    State = table.Column<byte>(type: "tinyint", nullable: false),
                    BankFullName = table.Column<string>(maxLength: 50, nullable: false),
                    AccountName = table.Column<string>(maxLength: 20, nullable: false),
                    AccountCardNumber = table.Column<string>(maxLength: 20, nullable: false),
                    ExtraRemark = table.Column<string>(maxLength: 50, nullable: true),
                    Remark = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepAccountDepositOrder", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RepAccountLog",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LogType = table.Column<byte>(type: "tinyint", nullable: false),
                    LogTitle = table.Column<string>(type: "varchar(20)", nullable: false),
                    UserID = table.Column<string>(maxLength: 50, nullable: false),
                    Information = table.Column<string>(maxLength: 300, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ClientIP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepAccountLog", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RepAccountWithdrawalOrder",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderNo = table.Column<string>(maxLength: 50, nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    UserID = table.Column<string>(maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    WithdrawalFee = table.Column<decimal>(type: "money", nullable: false),
                    State = table.Column<byte>(type: "tinyint", nullable: false),
                    BankFullName = table.Column<string>(maxLength: 50, nullable: false),
                    AccountName = table.Column<string>(maxLength: 20, nullable: false),
                    AccountCardNumber = table.Column<string>(maxLength: 20, nullable: false),
                    ExtraRemark = table.Column<string>(maxLength: 50, nullable: true),
                    Remark = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepAccountWithdrawalOrder", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AgentRate",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PaymentType = table.Column<int>(nullable: false),
                    Rate = table.Column<decimal>(type: "numeric(4, 2)", nullable: false),
                    State = table.Column<byte>(type: "tinyint", nullable: false),
                    Operator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: false),
                    AgentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentRate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AgentRate_Agent_AgentID",
                        column: x => x.AgentID,
                        principalTable: "Agent",
                        principalColumn: "AgentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Merchant",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MerchantUserID = table.Column<string>(maxLength: 20, nullable: false),
                    PassWord = table.Column<string>(maxLength: 50, nullable: false),
                    MerchantFullName = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    MerchantState = table.Column<byte>(type: "tinyint", nullable: false),
                    SettleType = table.Column<byte>(type: "tinyint", nullable: false),
                    Role = table.Column<byte>(type: "tinyint", nullable: false),
                    PrepaidRate = table.Column<decimal>(type: "numeric(4, 2)", nullable: false),
                    WithdrawalRate = table.Column<decimal>(type: "numeric(4, 2)", nullable: false),
                    Balance = table.Column<decimal>(type: "money", nullable: false),
                    Md5key = table.Column<string>(maxLength: 50, nullable: true),
                    Remark = table.Column<string>(maxLength: 100, nullable: true),
                    Operator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: false),
                    LastLoginTime = table.Column<DateTime>(nullable: false),
                    ClientIP = table.Column<string>(maxLength: 30, nullable: true),
                    AgentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchant", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Merchant_Agent_AgentID",
                        column: x => x.AgentID,
                        principalTable: "Agent",
                        principalColumn: "AgentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RepAccountCredit",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepositAmount = table.Column<decimal>(type: "money", nullable: false),
                    BonusAmount = table.Column<decimal>(type: "money", nullable: false),
                    FrozenAmount = table.Column<decimal>(nullable: false),
                    ReceiptAmount = table.Column<decimal>(type: "money", nullable: false),
                    Wechat = table.Column<decimal>(type: "money", nullable: false),
                    Alipay = table.Column<decimal>(type: "money", nullable: false),
                    UnionPay = table.Column<decimal>(type: "money", nullable: false),
                    MarketingFee = table.Column<decimal>(type: "money", nullable: false),
                    RepAccountID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepAccountCredit", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RepAccountCredit_RepAccount_RepAccountID",
                        column: x => x.RepAccountID,
                        principalTable: "RepAccount",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MerchantRate",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PaymentType = table.Column<int>(nullable: false),
                    Rate = table.Column<decimal>(type: "numeric(4, 2)", nullable: false),
                    State = table.Column<byte>(type: "tinyint", nullable: false),
                    Operator = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: false),
                    MerchantID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantRate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MerchantRate_Merchant_MerchantID",
                        column: x => x.MerchantID,
                        principalTable: "Merchant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgentRate_AgentID",
                table: "AgentRate",
                column: "AgentID");

            migrationBuilder.CreateIndex(
                name: "IX_Merchant_AgentID",
                table: "Merchant",
                column: "AgentID");

            migrationBuilder.CreateIndex(
                name: "IX_MerchantRate_MerchantID",
                table: "MerchantRate",
                column: "MerchantID");

            migrationBuilder.CreateIndex(
                name: "IX_RepAccountCredit_RepAccountID",
                table: "RepAccountCredit",
                column: "RepAccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentCreditLog");

            migrationBuilder.DropTable(
                name: "AgentOrder");

            migrationBuilder.DropTable(
                name: "AgentRate");

            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "MerchantCreditLog");

            migrationBuilder.DropTable(
                name: "MerchantOrder");

            migrationBuilder.DropTable(
                name: "MerchantRate");

            migrationBuilder.DropTable(
                name: "PaymentChannel");

            migrationBuilder.DropTable(
                name: "QRCode");

            migrationBuilder.DropTable(
                name: "ReceiptOrder");

            migrationBuilder.DropTable(
                name: "RepAccountCredit");

            migrationBuilder.DropTable(
                name: "RepAccountDepositOrder");

            migrationBuilder.DropTable(
                name: "RepAccountLog");

            migrationBuilder.DropTable(
                name: "RepAccountWithdrawalOrder");

            migrationBuilder.DropTable(
                name: "Merchant");

            migrationBuilder.DropTable(
                name: "RepAccount");

            migrationBuilder.DropTable(
                name: "Agent");
        }
    }
}
