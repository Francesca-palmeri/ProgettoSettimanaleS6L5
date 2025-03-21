﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProgettoSettimanaleS6L5.Models
{
    public class Prenotazione
    {
        [Key]
        public int PrenotazioneId { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public int CameraId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataInizio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataFine { get; set; }

        [Required]
        public string Stato { get; set; } // Esempio: "Confermata", "Cancellata", "In Attesa"

        // Navigational properties
        [ForeignKey(nameof(ClienteId))]
        public Cliente Cliente { get; set; }

        [ForeignKey(nameof(CameraId))]
        public Camera Camera { get; set; }
    }
}