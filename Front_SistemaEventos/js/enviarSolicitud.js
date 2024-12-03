class ReservationService {
    constructor(apiEndpoint) {
      this.apiEndpoint = apiEndpoint; // URL del endpoint API
      this.initialize();
    }
  
    // Inicializa el evento para enviar el formulario
    initialize() {
      const submitButton = document.getElementById("submitReservation");
      submitButton.addEventListener("click", () => this.sendReservation());
    }
  
    // Obtiene los valores del formulario
    getFormData() {
      return {
        usuarioID: 1,
        eventoID: document.getElementById("idEvento").value,
        nombreUsuario: document.getElementById("fullName").value,
        correo: document.getElementById("email").value,
        telefono: document.getElementById("phone").value,
        cantidadInvitados: document.getElementById("guests").value,
        fechaEvento: document.getElementById("eventDate").value,
        lugarEvento: document.getElementById("eventPlace").value,
        horarioPreferencia: document.getElementById("preferredTime").value,
        paqueteElegidoID: document.getElementById("idPaquete").value,
        estado: "1",
        fechaSolicitud: new Date()
      };
    }
  
    // Envía los datos mediante una solicitud POST
    async sendReservation() {
      const formData = this.getFormData();
  
      // Validar que todos los campos estén completos
      if (!this.validateForm(formData)) {
        //alert("Por favor, complete todos los campos.");
        Swal.fire({
          icon: "warning",
          title: "Campos incompletos",
          text: "Por favor, complete todos los campos.",
        });
        return;
      }
  
      try {
        const response = await fetch(this.apiEndpoint, {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(formData),
        });
  
        if (response.ok) {
          //alert("¡Solicitud enviada con éxito!");
          Swal.fire({
            icon: "success",
            title: "¡Éxito!",
            text: "¡Solicitud enviada con éxito!",
          });
          this.resetForm();
          const modalElement = document.getElementById('reservarModal');
          const modalInstance = bootstrap.Modal.getInstance(modalElement);
          modalInstance.hide(); // Cierra el modal
        } else {
          const errorData = await response.json();
          //alert(`Error al enviar la solicitud: ${errorData.message || 'Intente nuevamente más tarde.'}`);
          Swal.fire({
            icon: "error",
            title: "Error",
            text: `Error al enviar la solicitud: ${errorData.message || 'Intente nuevamente más tarde.'}`,
          });
        }
      } catch (error) {
        console.error("Error al enviar la solicitud:", error);
        //alert("Hubo un problema al procesar la solicitud. Intente nuevamente.");
        Swal.fire({
          icon: "error",
          title: "Error",
          text: "Hubo un problema al procesar la solicitud. Intente nuevamente."
        });
      }
    }
  
    // Resetea el formulario
    resetForm() {
      document.getElementById("reservationForm").reset();
    }
  
    // Valida el formulario (asegura que todos los campos estén completos)
    validateForm(data) {
      return Object.values(data).every(value => String(value).trim() !== "");
    }
  }
  
  // Inicializa la clase con el endpoint de la API
  document.addEventListener("DOMContentLoaded", () => {
    new ReservationService("http://localhost:5159/api/Solicitudes");
});