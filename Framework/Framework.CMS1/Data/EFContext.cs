// ============================================================================
// Project: Toolkit Apps
// Name/Class: DataContext
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 04/Oct/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using System.Data.Entity;

namespace Framework.CMS1.Data
{
    public static class EFContext
    {
        //
        // Create the model for this namespace using the entityframework
        // builder reference.
        //

        public static void OnCreateModel(DbModelBuilder modelBuilder)
        {
            //
            // Clusters
            //

            modelBuilder.Entity<Framework.CMS1.Model.Cluster>()
                .ToTable("TK_CMS_CLUSTER")
                .HasKey(t => t.ID);

            modelBuilder.Entity<Framework.CMS1.Model.Cluster>()
                .HasMany<Framework.CMS1.Model.Entities.Entity>(s => s.Entities)
                .WithRequired(c => c.Owner)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Framework.CMS1.Model.Cluster>()
                .HasMany<Framework.CMS1.Model.Types.ContentType>(s => s.ContentTypes)
                .WithRequired(c => c.Owner)
                .WillCascadeOnDelete();

            //
            // Types
            //

            modelBuilder.Entity<Framework.CMS1.Model.Types.ContentType>()
                .ToTable("TK_CMS_TYP_CONTENT_TYPE")
                .HasKey(t => t.ID);

            //
            // Entities
            //

            modelBuilder.Entity<Framework.CMS1.Model.Entities.Entity>()
                .ToTable("TK_CMS_ENT_ENTITY")
                .HasKey(t => t.ID);

            modelBuilder.Entity<Framework.CMS1.Model.Entities.Definition>()
                .ToTable("TK_CMS_ENT_DEFINITION")
                .HasKey(t => t.ID);

            modelBuilder.Entity<Framework.CMS1.Model.Entities.Property>()
                .ToTable("TK_CMS_ENT_PROPERTY")
                .HasKey(t => t.ID);

            modelBuilder.Entity<Framework.CMS1.Model.Entities.Form>()
                .ToTable("TK_CMS_ENT_FORM")
                .HasKey(t => t.ID);

            modelBuilder.Entity<Framework.CMS1.Model.Entities.Schema>()
                .ToTable("TK_CMS_ENT_SCHEMA")
                .HasKey(t => t.ID);

            modelBuilder.Entity<Framework.CMS1.Model.Views.View>()
                .ToTable("TK_CMS_ENT_VIEW")
                .HasKey(t => t.ID);

            modelBuilder.Entity<Framework.CMS1.Model.Views.Field>()
                .ToTable("TK_CMS_ENT_VIEW_FIELD")
                .HasKey(t => t.ID);

            modelBuilder.Entity<Framework.CMS1.Model.Entities.Entity>()
                .HasMany<Framework.CMS1.Model.Views.View>(s => s.Views)
                .WithRequired(c => c.Owner)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Framework.CMS1.Model.Entities.Entity>()
                .HasMany<Framework.CMS1.Model.Entities.Schema>(s => s.Schemas)
                .WithRequired(c => c.Owner)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Framework.CMS1.Model.Entities.Entity>()
                .HasMany<Framework.CMS1.Model.Entities.Form>(s => s.Forms)
                .WithRequired(c => c.Owner)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Framework.CMS1.Model.Entities.Schema>()
                .HasMany<Framework.CMS1.Model.Entities.Property>(s => s.Properties)
                .WithRequired(c => c.Owner)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Framework.CMS1.Model.Views.View>()
                .HasMany<Framework.CMS1.Model.Views.Field>(s => s.Fields)
                .WithRequired(c => c.Owner)
                .WillCascadeOnDelete();

        }
    }
}
