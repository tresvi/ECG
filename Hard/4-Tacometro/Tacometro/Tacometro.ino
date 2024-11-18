volatile int contadorPulsos = 0; // Variable para contar los pulsos
unsigned long tiempoAnterior = 0;
int rpm = 0;

void setup() {
  pinMode(2, INPUT_PULLUP); // Pin de interrupción (sensor conectado a pin digital 2)
  attachInterrupt(digitalPinToInterrupt(2), contarPulsos, FALLING);
  Serial.begin(115200);
}

void loop() {
  // Calcular RPM cada segundo
  unsigned long tiempoActual = millis();
  if (tiempoActual - tiempoAnterior >= 1000) {
    detachInterrupt(digitalPinToInterrupt(2)); // Detener la interrupción para evitar inconsistencias

    // Calcular RPM (contadorPulsos / tiempo en segundos) * 60
    rpm = contadorPulsos;  //El encoder envia 60 pulsos por revolucion
    Serial.println(rpm);

    contadorPulsos = 0; // Reiniciar contador de pulsos
    tiempoAnterior = tiempoActual;

    attachInterrupt(digitalPinToInterrupt(2), contarPulsos, FALLING); // Reactivar interrupción
  }
}

// Función de interrupción para contar pulsos
void contarPulsos() {
  contadorPulsos++;
}
