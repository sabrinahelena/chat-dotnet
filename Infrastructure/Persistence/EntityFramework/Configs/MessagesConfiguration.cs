using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityFramework.Configs;

public class MessagesConfiguration: IEntityTypeConfiguration<MessageEntity>
{
    public void Configure(EntityTypeBuilder<MessageEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable("messages");

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(p => p.Content)
            .HasColumnName("content")
            .IsRequired();

        builder.Property(p => p.SentAt)
            .HasColumnName("sent_at")
            .IsRequired();
        
        builder.HasOne(p => p.Sender)
            .WithMany()
            .HasForeignKey(p => p.SenderId);

        builder.HasOne(p => p.Receiver)
            .WithMany()
            .HasForeignKey(p => p.ReceiverId);

        builder.HasOne(p => p.GroupChat)
            .WithMany()
            .HasForeignKey(p => p.GroupChatId);
    }
}