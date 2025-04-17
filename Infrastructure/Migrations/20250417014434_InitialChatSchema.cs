using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialChatSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_GroupChats_GroupChatId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_ReceiverId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_SenderId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_GroupChats_GroupChatEntityId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_GroupChatEntityId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupChats",
                table: "GroupChats");

            migrationBuilder.DropColumn(
                name: "GroupChatEntityId",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "messages");

            migrationBuilder.RenameTable(
                name: "GroupChats",
                newName: "group_chats");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "users",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "users",
                newName: "login");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "messages",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "messages",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SentAt",
                table: "messages",
                newName: "sent_at");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_SenderId",
                table: "messages",
                newName: "IX_messages_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ReceiverId",
                table: "messages",
                newName: "IX_messages_ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_GroupChatId",
                table: "messages",
                newName: "IX_messages_GroupChatId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "group_chats",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "group_chats",
                newName: "created_at");

            migrationBuilder.AddColumn<Guid>(
                name: "GroupChatEntityId",
                table: "messages",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_messages",
                table: "messages",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_group_chats",
                table: "group_chats",
                column: "id");

            migrationBuilder.CreateTable(
                name: "group_chat_members",
                columns: table => new
                {
                    GroupChatsId = table.Column<Guid>(type: "uuid", nullable: false),
                    MembersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group_chat_members", x => new { x.GroupChatsId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_group_chat_members_group_chats_GroupChatsId",
                        column: x => x.GroupChatsId,
                        principalTable: "group_chats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_group_chat_members_users_MembersId",
                        column: x => x.MembersId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_messages_GroupChatEntityId",
                table: "messages",
                column: "GroupChatEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_group_chat_members_MembersId",
                table: "group_chat_members",
                column: "MembersId");

            migrationBuilder.AddForeignKey(
                name: "FK_messages_group_chats_GroupChatEntityId",
                table: "messages",
                column: "GroupChatEntityId",
                principalTable: "group_chats",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_messages_group_chats_GroupChatId",
                table: "messages",
                column: "GroupChatId",
                principalTable: "group_chats",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_messages_users_ReceiverId",
                table: "messages",
                column: "ReceiverId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_messages_users_SenderId",
                table: "messages",
                column: "SenderId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_messages_group_chats_GroupChatEntityId",
                table: "messages");

            migrationBuilder.DropForeignKey(
                name: "FK_messages_group_chats_GroupChatId",
                table: "messages");

            migrationBuilder.DropForeignKey(
                name: "FK_messages_users_ReceiverId",
                table: "messages");

            migrationBuilder.DropForeignKey(
                name: "FK_messages_users_SenderId",
                table: "messages");

            migrationBuilder.DropTable(
                name: "group_chat_members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_messages",
                table: "messages");

            migrationBuilder.DropIndex(
                name: "IX_messages_GroupChatEntityId",
                table: "messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_group_chats",
                table: "group_chats");

            migrationBuilder.DropColumn(
                name: "GroupChatEntityId",
                table: "messages");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "messages",
                newName: "Messages");

            migrationBuilder.RenameTable(
                name: "group_chats",
                newName: "GroupChats");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "login",
                table: "Users",
                newName: "Login");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "Messages",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Messages",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "sent_at",
                table: "Messages",
                newName: "SentAt");

            migrationBuilder.RenameIndex(
                name: "IX_messages_SenderId",
                table: "Messages",
                newName: "IX_Messages_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_messages_ReceiverId",
                table: "Messages",
                newName: "IX_Messages_ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_messages_GroupChatId",
                table: "Messages",
                newName: "IX_Messages_GroupChatId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "GroupChats",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "GroupChats",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<Guid>(
                name: "GroupChatEntityId",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupChats",
                table: "GroupChats",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupChatEntityId",
                table: "Users",
                column: "GroupChatEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_GroupChats_GroupChatId",
                table: "Messages",
                column: "GroupChatId",
                principalTable: "GroupChats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_ReceiverId",
                table: "Messages",
                column: "ReceiverId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_GroupChats_GroupChatEntityId",
                table: "Users",
                column: "GroupChatEntityId",
                principalTable: "GroupChats",
                principalColumn: "Id");
        }
    }
}
