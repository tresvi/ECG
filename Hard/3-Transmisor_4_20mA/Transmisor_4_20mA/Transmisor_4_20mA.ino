void setup(){
 // Inicializar la comunicación en serie:
  Serial.begin(115200);
  pinMode(10, INPUT); // Configuración para la detección LO +
  pinMode(11, INPUT); // Configuración para la detección LO -
}

void loop() {
  if((digitalRead(10) == 1)||(digitalRead(11) == 1)){
    Serial.println('!');
  }
  else{
    // Imprimir la lectura del puerto A0
    Serial.println(analogRead(A0));
  }
  
  //Espere un poco para evitar que los datos en serie se saturen
  delay(1);
}
