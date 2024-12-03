<?php
// Conexión a la base de datos
$servername = "localhost"; // Cambia si es necesario
$username = "root";        // Usuario de la base de datos
$password = "";            // Contraseña de la base de datos
$dbname = "info";          // Nombre de la base de datos

// Crear conexión
$conn = new mysqli($servername, $username, $password, $dbname);

// Verificar conexión
if ($conn->connect_error) {
    die("Error de conexión: " . $conn->connect_error);
}

// Verificar que los datos sean enviados por POST
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // Recibir y sanitizar los datos del formulario
    $nombre = $conn->real_escape_string($_POST['name']);
    $correo = $conn->real_escape_string($_POST['email']);
    $asunto = $conn->real_escape_string($_POST['subject']);
    $mensaje = $conn->real_escape_string($_POST['message']);

    // Insertar datos en la tabla
    $sql = "INSERT INTO pedidos (nombre, correo, asunto, mensaje) 
            VALUES ('$nombre', '$correo', '$asunto', '$mensaje')";

    if ($conn->query($sql) === TRUE) {
        echo "Mensaje enviado correctamente.";
    } else {
        echo "Error: " . $sql . "<br>" . $conn->error;
    }
}

// Cerrar la conexión
$conn->close();
?>
