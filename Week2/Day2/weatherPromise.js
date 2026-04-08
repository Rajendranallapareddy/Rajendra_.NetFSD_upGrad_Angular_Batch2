const latitude = 17.3850;
const longitude = 78.4867;

const url = `https://api.open-meteo.com/v1/forecast?latitude=${latitude}&longitude=${longitude}&current_weather=true`;

fetch(url)
    .then(response => {
        if (!response.ok) {
            throw new Error("Network response was not ok");
        }
        return response.json();
    })
    .then(data => {

        const { temperature, windspeed } = data.current_weather;

        const report = `
========================
      WEATHER REPORT
========================
Temperature: ${temperature}°C
Wind Speed : ${windspeed} km/h
========================
`;

        console.log(report);
    })
    .catch(error => {
        console.error("Error fetching weather data:", error.message);
    });