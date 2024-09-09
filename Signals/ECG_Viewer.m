ylabel('Amplitud');
n = length(ecgSignal);        % Número de muestras
t = (0:n-1) / Fs;             % Vector de tiempo
plot(t, ecgSignal);
title('Señal de ECG vs Tiempo');
xlabel('Tiempo (segundos)');
ylabel('Amplitud');
ecgsignal
csvwrite('ecgSignal.csv', ecgSignal);
ecgsignal
title('Señal de ECG vs Tiempo');
plot(t, ecgSignal);
plot(t, ecgSignal);
plot(t, ecgSignal);

