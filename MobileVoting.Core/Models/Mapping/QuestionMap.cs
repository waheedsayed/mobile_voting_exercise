using System.Data.Entity.ModelConfiguration;

namespace MobileVoting.Core.Models.Mapping
{
    public class QuestionMap : EntityTypeConfiguration<Question>
    {
        public QuestionMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.Text)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            ToTable("Questions");
            Property(t => t.Id).HasColumnName("QuestionId");
            Property(t => t.Title).HasColumnName("Title");
            Property(t => t.Text).HasColumnName("Text");
            Property(t => t.IsActive).HasColumnName("IsActive");
            Property(t => t.TypeId).HasColumnName("TypeId");
            Property(t => t.DateCreated).HasColumnName("DateCreated");
            Property(t => t.LastModified).HasColumnName("LastModified");

            // Relationships
            HasRequired(t => t.Type)
                .WithMany(t => t.Questions)
                .HasForeignKey(d => d.TypeId)
                .WillCascadeOnDelete(false);
        }
    }
}