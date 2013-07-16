using System.Data.Entity.ModelConfiguration;

namespace MobileVoting.Core.Models.Mapping
{
    public class QuestionOptionMap : EntityTypeConfiguration<QuestionOption>
    {
        public QuestionOptionMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Text)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            ToTable("QuestionOptions");
            Property(t => t.Id).HasColumnName("OptionId");
            Property(t => t.Text).HasColumnName("Text");
            Property(t => t.QuestionId).HasColumnName("QuestionId");

            // Relationships
            HasRequired(t => t.Question)
                .WithMany(t => t.Options)
                .HasForeignKey(d => d.QuestionId)
                .WillCascadeOnDelete(false);
        }
    }
}