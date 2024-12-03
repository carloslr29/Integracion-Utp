document.addEventListener("DOMContentLoaded", () => {
    const idEvento = getUrlParameter('id');
    const apiEndpoint = "http://localhost:5159/api/Paquetes/PaquetePorEvento/" + idEvento; // Cambia por la URL real de la API
    const container = document.getElementById("packages-container");

    const createPackageHTML = (paquete, index) => {
      // Alterna las clases basadas en el índice (par o impar)
      const className = (index % 2 === 0) ? 'col-md-5 d-flex align-items-center' : 'col-md-5 order-1 order-md-2 d-flex align-items-center';
      const className2 = (index % 2 === 0) ? 'col-md-7' : 'col-md-7 order-2 order-md-1';

      return `
        <div class="row gy-4 align-items-center features-item">
          <div class="${className}" data-aos="zoom-out">
            <img src="${paquete.urlImagen}" class="img-fluid" alt="${paquete.nombrePaquete}">
          </div>
          <div class="${className2}" data-aos="fade-up">
            <h3>${paquete.nombrePaquete} - S/ ${paquete.precio}</h3>
            <p class="fst-italic">${paquete.descripcionPaquete}</p>
            <ul>
              ${paquete.detallePaquete.map(detalle => `<li><i class="bi bi-check"></i> ${detalle.descripcion}</li>`).join('')}
            </ul>
            <button class="btn btn-primary mt-3" onclick="openModal(${paquete.eventoID}, ${paquete.paqueteID}, '${paquete.nombrePaquete}')">Contratar Paquete</button>
          </div>
        </div>
      `;
    };

    const loadPackages = async () => {
      try {
        const response = await fetch(apiEndpoint);
        if (!response.ok) throw new Error("Error al obtener los datos de la API");

        const paquetes = await response.json();
        container.innerHTML = paquetes.map((paquete, index) => createPackageHTML(paquete, index)).join('');
        AOS.refresh(); // Refresca las animaciones de AOS después de cargar los paquetes
      } catch (error) {
        console.error("Error cargando paquetes:", error);
        container.innerHTML = "<p>Error cargando los paquetes. Intenta nuevamente más tarde.</p>";
      }
    };

    loadPackages();

    // Función para abrir el modal y personalizar el contenido si es necesario
    window.openModal = (idEvento, idPaquete, nombrePaquete) => {
      if (!document.querySelector('script[src="js/enviarSolicitud.js"]')) {
        const script = document.createElement('script');
        script.src = "js/enviarSolicitud.js";
        script.onload = () => {
          // Después de cargar el script, proceder con la lógica del modal
          loadModal(idEvento, idPaquete, nombrePaquete);
        };
        document.body.appendChild(script);
      } else {
        // Si el script ya está cargado, solo procedemos con la carga del modal
        loadModal(idEvento, idPaquete, nombrePaquete);
      }

      
    };

    function loadModal(idEvento, idPaquete, nombrePaquete) {
        let modalElement = document.getElementById('reservarModal');
        
        // Si el modal no está en el DOM, lo cargamos
        if (!modalElement) {
          fetch('ReservarPaquete.html')
            .then(response => response.text())
            .then(data => {
              document.body.insertAdjacentHTML('beforeend', data);
              modalElement = document.getElementById('reservarModal');
              initializeModal(modalElement, idEvento, idPaquete, nombrePaquete);
            })
            .catch(error => console.error('Error al cargar el modal:', error));
        } else {
          // Si el modal ya existe, solo lo inicializamos y lo mostramos
          initializeModal(modalElement, idEvento, idPaquete, nombrePaquete);
        }
      }
      
      function initializeModal(modalElement, idEvento, idPaquete, nombrePaquete) {
        // Verificar si el modal ya tiene un listener para evitar la duplicación
        const submitButton = document.getElementById("submitReservation");
      
        // Eliminar cualquier listener previo para evitar duplicados
        submitButton.removeEventListener("click", handleSubmit);
      
        // Destruir cualquier instancia previa del modal si existe
        const modalInstance = bootstrap.Modal.getInstance(modalElement);
        if (modalInstance) {
          modalInstance.dispose();  // Destruir la instancia antigua
        }
      
        // Inicializar una nueva instancia del modal
        const modal = new bootstrap.Modal(modalElement);
      
        // Establecer los valores dinámicos
        const modalTitle = document.getElementById("reservarModalLabel");
        const idEventoInput = document.getElementById("idEvento");
        const idPaqueteInput = document.getElementById("idPaquete");
      
        modalTitle.innerHTML = `Reservar Paquete: ${nombrePaquete}`;
        idEventoInput.value = idEvento; // Asigna el idEvento
        idPaqueteInput.value = idPaquete; // Asigna el idPaquete
      
        modal.show(); // Mostrar el modal
      
        // Asegurarse de que aria-hidden no esté presente cuando el modal se muestra
        modalElement.removeAttribute("aria-hidden");

        // Eliminar cualquier listener previo antes de agregar uno nuevo
        submitButton.removeEventListener("click", handleSubmit);

        // Asegurarse de que el evento solo se registre una vez
        submitButton.addEventListener("click", handleSubmit);

        // Cuando el modal se cierre, eliminar el atributo inert
        modalElement.addEventListener('hidden.bs.modal', () => {
            modalElement.remove(); // Elimina el modal completamente del DOM
        });
      }
      
      function handleSubmit() {
        // Crear una instancia de ReservationService para enviar la solicitud
        new ReservationService("http://localhost:5159/api/Solicitudes").sendReservation();
        // Para evitar llamadas múltiples, eliminamos el evento después de la primera ejecución
        const submitButton = document.getElementById("submitReservation");
        submitButton.removeEventListener("click", handleSubmit);
      }
});

// Función para obtener parámetros de la URL
function getUrlParameter(name) {
    const urlParams = new URLSearchParams(window.location.search);
    return urlParams.get(name);
}