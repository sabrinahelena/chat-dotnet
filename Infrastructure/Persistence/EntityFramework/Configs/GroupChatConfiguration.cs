using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityFramework.Configs;

public class GroupChatConfiguration : IEntityTypeConfiguration<GroupChatEntity>
{
    public void Configure(EntityTypeBuilder<GroupChatEntity> builder)
    {
        builder.HasKey(gc => gc.Id);

        builder.ToTable("group_chats");

        builder.Property(gc => gc.Id)
            .HasColumnName("id")
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(gc => gc.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.HasMany(gc => gc.Messages)
            .WithOne(m => m.GroupChat)
            .HasForeignKey(m => m.GroupChatId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(gc => gc.Members)
            .WithMany(u => u.GroupChats)
            .UsingEntity(j => j.ToTable("group_chat_members"));
    }
}