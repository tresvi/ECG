long valor=0;
void setup() {
  // put your setup code here, to run once:
    Serial.begin(9600);
  
}

void loop() {
  // put your main code here, to run repeatedly:
 valor = analogRead(A0);
 
  //Imprimimos por el monitor serie
  Serial.println(valor);
  delay(5);
}
