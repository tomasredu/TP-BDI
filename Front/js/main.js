

//INICIO NACHO
const homeBtn = document.querySelector("#home");
const consulta1Btn = document.querySelector("#consulta_1");
const consulta2Btn = document.querySelector("#consulta_2");
const consulta3Btn = document.querySelector("#consulta_3");
const consulta4Btn = document.querySelector("#consulta_4");
const consulta5Btn = document.querySelector("#consulta_5");
const consulta6Btn = document.querySelector("#consulta_6");
const consulta7Btn = document.querySelector("#consulta_7");
const consulta8Btn = document.querySelector("#consulta_8");


homeBtn.addEventListener("click", handleHomeClick);
consulta1Btn.addEventListener("click", handleConsulta1Click);
consulta2Btn.addEventListener("click", handleConsulta2Click);
consulta5Btn.addEventListener("click", handleConsulta5Click);
consulta6Btn.addEventListener("click", handleConsulta6Click);
consulta7Btn.addEventListener("click", handleConsulta7Click);
consulta8Btn.addEventListener("click", handleConsulta8Click);

function handleHomeClick() {
  clearMain();
  //Hacer funcion renderHome();
}

function handleConsulta1Click() {
  clearMain();
  renderConsulta1();
}

function handleConsulta2Click() {
  clearMain();
  renderConsulta2();
}

function handleConsulta5Click() {
  clearMain();
  renderSala();
  paintDivs();
}

async function handleConsulta6Click() {
  clearMain();
  await renderConsulta6();
  await renderChart();
}

function handleConsulta7Click() {
  clearMain();
  cargarConsulta7();
}

function handleConsulta8Click() {
  clearMain();
  cargarConsulta8();
}

function clearMain() {
  const main = document.querySelector("main");
  while (main.firstChild) {
    main.removeChild(main.firstChild);
  }
}

function renderConsulta1() {
  const main = document.querySelector("main");
  const section = document.createElement("section");
  section.classList.add("top-10");
  main.appendChild(section);
  const h1 = document.createElement("h1");
  h1.textContent = "Top 10 Peliculas Mas y Menos Vendidas";
  h1.classList.add("text-center", "mb-4");
  section.appendChild(h1);

  const tableWrapper = document.createElement("div");
  tableWrapper.classList.add("table-responsive");
  section.appendChild(tableWrapper);

  const table = document.createElement("table");
  table.classList.add(
    "table",
    "table-striped",
    "table-hover",
    "table-bordered"
  );
  tableWrapper.appendChild(table);

  const thead = document.createElement("thead");
  table.appendChild(thead);

  const tr = document.createElement("tr");
  thead.appendChild(tr);

  const th1 = document.createElement("th");
  th1.textContent = "Película";
  th1.classList.add("text-center", "fw-bold");
  tr.appendChild(th1);

  const th2 = document.createElement("th");
  th2.textContent = "Entradas Vendidas";
  th2.classList.add("text-center", "fw-bold");
  tr.appendChild(th2);

  const th3 = document.createElement("th");
  th3.textContent = "Estado";
  th3.classList.add("text-center", "fw-bold");
  tr.appendChild(th3);

  const tbody = document.createElement("tbody");
  table.appendChild(tbody);

  // Traer top10
  fetch("https://localhost:7215/api/Test/top-bottom")
    .then((response) => {
      if (!response.ok) {
        throw new Error("Network response was not ok");
      }
      console.log(response);
      return response.json();
    })
    .then((data) => {
      data.forEach((item) => {
        console.log(item);
        const tr = document.createElement("tr");
        tbody.appendChild(tr);

        const td1 = document.createElement("td");
        td1.textContent = item.titulo;
        tr.appendChild(td1);

        const td2 = document.createElement("td");
        td2.textContent = item.entradasVendidas;
        tr.appendChild(td2);

        const td3 = document.createElement("td");
        td3.textContent = item.estado;
        tr.appendChild(td3);
      });
    })
    .catch((error) => {
      console.error("There was a problem with the fetch operation:", error);
      const errorMsg = document.createElement("tr");
      const errorTd = document.createElement("td");
      errorTd.colSpan = 3;
      errorTd.textContent = "Error al cargar los datos.";
      errorMsg.appendChild(errorTd);
      tbody.appendChild(errorMsg);
    });
}
function renderConsulta2() {
  const main = document.querySelector("main");
  const section = document.createElement("section");
  section.classList.add("top-10");
  main.appendChild(section);

  const h1 = document.createElement("h1");
  h1.textContent =
    "Consultar Lugar en Funciones Subtituladas o No Subtituladas";
  h1.classList.add("text-center", "mb-4");
  section.appendChild(h1);

  const btnWrapper = document.createElement("div");
  btnWrapper.classList.add("text-center", "mb-4");
  section.appendChild(btnWrapper);

  const subtitledBtn = document.createElement("button");
  subtitledBtn.textContent = "Funciones Subtituladas";
  subtitledBtn.classList.add("btn", "btn-primary", "mx-2");
  subtitledBtn.addEventListener("click", () => fetchAndRenderFunctions(true));
  btnWrapper.appendChild(subtitledBtn);

  const nonSubtitledBtn = document.createElement("button");
  nonSubtitledBtn.textContent = "Funciones No Subtituladas";
  nonSubtitledBtn.classList.add("btn", "btn-secondary", "mx-2");
  nonSubtitledBtn.addEventListener("click", () =>
    fetchAndRenderFunctions(false)
  );
  btnWrapper.appendChild(nonSubtitledBtn);

  const tableWrapper = document.createElement("div");
  tableWrapper.classList.add("table-responsive");
  section.appendChild(tableWrapper);

  const tbody = document.createElement("tbody");
  let table;

  function fetchAndRenderFunctions(isSubtitled) {
    const url = isSubtitled
      ? "https://localhost:7215/api/Test/today-subtitled"
      : "https://localhost:7215/api/Test/today-non-subtitled";

    fetch(url)
      .then((response) => {
        if (!response.ok) {
          throw new Error("Network response was not ok");
        }
        return response.json();
      })
      .then((data) => {
        if (!table) {
          table = document.createElement("table");
          table.classList.add(
            "table",
            "table-striped",
            "table-hover",
            "table-bordered"
          );
          tableWrapper.appendChild(table);

          const thead = document.createElement("thead");
          table.appendChild(thead);

          const tr = document.createElement("tr");
          thead.appendChild(tr);

          ["Película", "Horario", "Sala", "Subtitulada", "Acciones"].forEach(
            (text) => {
              const th = document.createElement("th");
              th.textContent = text;
              th.classList.add("text-center", "fw-bold");
              tr.appendChild(th);
            }
          );

          table.appendChild(tbody);
        }

        tbody.innerHTML = "";

        data.forEach((item) => {
          console.log(item);
          const tr = document.createElement("tr");
          tbody.appendChild(tr);

          const td1 = document.createElement("td");
          td1.textContent = item.pelicula;
          tr.appendChild(td1);

          const td2 = document.createElement("td");
          td2.textContent = new Date(item.horario).toLocaleString();
          tr.appendChild(td2);

          const td3 = document.createElement("td");
          td3.textContent = item.sala;
          tr.appendChild(td3);

          const td4 = document.createElement("td");
          td4.textContent = item.subtitulada ? "Sí" : "No";
          tr.appendChild(td4);

          // Boton para chequear disponibilidad
          const td5 = document.createElement("td");
          const checkButton = document.createElement("button");
          checkButton.textContent = "CONSULTAR LUGAR";
          checkButton.classList.add("btn", "btn-info", "btn-sm");
          checkButton.addEventListener("click", () =>
            fetchAvailability(item.id_funcion)
          );
          td5.appendChild(checkButton);
          tr.appendChild(td5);
        });
      })
      .catch((error) => {
        console.error("There was a problem with the fetch operation:", error);
        tbody.innerHTML =
          "<tr><td colspan='5'>Error al cargar los datos.</td></tr>";
      });
  }
}

function fetchAvailability(id) {
  fetch(`https://localhost:7215/api/Test/has-availability?id=${id}`)
    .then((response) => {
      if (!response.ok) {
        throw new Error("Network response was not ok");
      }
      return response.json();
    })
    .then((data) => {
      // Llenar modal
      document.getElementById("modalCapacidad").textContent = data[0].capacidad;
      document.getElementById("modalEntradasVendidas").textContent =
        data[0].entradasVendidas;
      document.getElementById("modalHayLugar").textContent = data[0].hayLugar
        ? "Sí, hay lugar disponible."
        : "No, no hay lugar disponible.";

      // Mostrar Modal
      const modal = new bootstrap.Modal(
        document.getElementById("availabilityModal")
      );
      modal.show();
    })
    .catch((error) => {
      console.error("There was a problem with the fetch operation:", error);
    });
}
// FIN NACHO


//INICIO BRUNELLA
//CONSULTA 7

//cargar el desplegable de idiomas
function cargarIdiomas() {
  const selectIdioma = document.getElementById('selectIdioma');

  fetch('https://localhost:7215/Idiomas') 
      .then(response => {
          if (!response.ok) {
              throw new Error('Error en la respuesta de la API');
          }
          return response.json();
      })
      .then(data => {
          data.forEach(idioma => {
              const option = document.createElement('option');
              option.value = idioma.idIdioma;
              option.textContent = idioma.idioma1;
              selectIdioma.appendChild(option);
          });
      })
      .catch(error => {
          console.error('Error al cargar los idiomas:', error);
      });
}

//cargar el contenido consulta7.html al section del index.html
function cargarConsulta7() {
  const section = document.createElement('section');
  section.id = 'consulta7';
  document.querySelector('main').appendChild(section);

  fetch('consulta7.html')
      .then(response => {
          if (!response.ok) {
              throw new Error('Error al cargar el contenido');
          }
          return response.text();
      })
      .then(html => {
          document.getElementById('consulta7').innerHTML = html;
          // Llama a la función para cargar los idiomas en el select
          cargarIdiomas();
      })
      .catch(error => {
          console.error('Error al cargar el contenido de consulta7:', error);
      });
}

// función del botón buscar de la consulta 7
function buscarIdioma() {
  const selectIdioma = document.getElementById('selectIdioma');
  const idIdioma = selectIdioma.value; 

  if (idIdioma) {
      fetch(`https://localhost:7215/api/Test/reservas-idiomas?idIdioma=${idIdioma}`) 
          .then(response => {
              if (!response.ok) {
                  throw new Error('Error en la respuesta de la API');
              }
              return response.json();
          })
          .then(data => {
              mostrarResultados(data);
          })
          .catch(error => {
              console.error('Error al cargar los resultados:', error);
              document.getElementById('resultadosIdioma').innerHTML = `<p>Error al cargar los resultados</p>`;
          });
  } else {
      alert("Por favor, selecciona un idioma.");
  }
}

// función para mostrar los resultados de la API
function mostrarResultados(data) {
  const resultadosContainer = document.getElementById('resultadosIdioma');
  resultadosContainer.innerHTML = `
      <table class="table table-striped table-hover">
          <thead class="table-light">
              <tr>
                  <th>Total de butacas ocupadas</th>
                  <th>Ingresos totales</th>
              </tr>
          </thead>
          <tbody>
              <tr>
                  <td>${data.totalButacasOcupadas}</td>
                  <td>$${data.ingresosTotales.toFixed(2)}</td>
              </tr>
          </tbody>
      </table>
  `;
}


//CONSULTA 8

let reservasChart;


// función para cargar el contenido de consulta8.html en el section
function cargarConsulta8() {
    fetch('consulta8.html')
        .then(response => {
            if (!response.ok) {
                throw new Error('No se pudo cargar el contenido');
            }
            return response.text();
        })
        .then(html => {
            document.getElementById('consulta8').innerHTML = html;
        })
        .catch(error => {
            console.error('Error al cargar consulta8.html:', error);
        });
}


//  llamada a la API y obtener resultados
function buscarReservasPorAño() {
  const selectAño = document.getElementById('selectAño');
  const añoSeleccionado = selectAño.value;


  if (añoSeleccionado) {
      fetch(`https://localhost:7191/api/Consultas/cantidad-reservas/${añoSeleccionado}`)
          .then(response => {
              if (!response.ok) {
                  throw new Error('Error en la respuesta de la API');
              }
              return response.json();
          })
          .then(data => {
              renderizarGrafico(data);
          })
          .catch(error => {
              console.error('Error al cargar los resultados:', error);
              document.getElementById('resultadosReservasAño').innerHTML = `<p>Error al cargar los resultados</p>`;
          });
  } else {
      alert("Por favor, selecciona un año.");
  }
}


// mostrar los resultados de la API
function mostrarResultadosReservasAño(data) {
  const resultadosContainer = document.getElementById('resultadosReservasAño');
  if (data && Array.isArray(data) && data.length) {
      let html = `
          <table class="table table-striped table-hover">
              <thead class="table-light">
                  <tr>
                      <th>Estado de Reserva</th>
                      <th>Cantidad de Clientes</th>
                  </tr>
              </thead>
              <tbody>`;
      
      data.forEach(item => {
          html += `
              <tr>
                  <td>${item.estadoReserva}</td>
                  <td>${item.cantidadClientes}</td>
              </tr>`;
      });

      html += `
              </tbody>
              </table>`;
      resultadosContainer.innerHTML = html;
  } else {
      resultadosContainer.innerHTML = `<p>No se encontraron resultados para el año seleccionado.</p>`;
  }
}

function renderizarGrafico(data) {
  const resultadosContainer = document.getElementById('resultadosReservasAño');
  const reservasChartCanvas = document.getElementById('reservasChart');


  // Limpiar el canvas
  if (reservasChart) {
      reservasChart.destroy(); // Destruir el gráfico anterior si existe
  }


  // Crear etiquetas y datos para el gráfico
  const labels = data.map(item => item.estadoReserva); // Obtener etiquetas de estado de reserva
  const valores = data.map(item => item.cantidadClientes); // Obtener cantidades


  // Configuración del gráfico
  const config = {
      type: 'bar',
      data: {
          labels: labels,
          datasets: [{
              label: 'Cantidad de Clientes',
              data: valores,
              backgroundColor: [
                  'rgba(255, 99, 132, 0.5)', // Color para reservas confirmadas
                  'rgba(54, 162, 235, 0.5)'  // Color para reservas no confirmadas
              ],
          }]
      },
      options: {
          plugins: {
              title: {
                  display: true,
                  text: 'Cantidad de Clientes por Estado de Reserva',
                  font: {
                      size: 20
                  }
              },
              legend: {
                  display: false
              },
          },
          responsive: true,
          scales: {
              x: {
                  stacked: true,
              },
              y: {
                  stacked: true,
                  beginAtZero: true, // Comenzar el eje y en 0
                  ticks: {
                      // Modificación de los ticks en el eje Y
                      callback: function(value) {
                          return Number.isInteger(value) ? value : ''; // Mostrar solo números enteros
                      }
                  }
              }
          }
      }
  };


  // Crear el gráfico
  reservasChart = new Chart(reservasChartCanvas, config);
}


//FIN BRUNELLA

//INICIO TOMAS

async function getResumen() {
  var promise = await fetch("https://localhost:7215/api/Test/resumen");
  var result = await promise.json();
  return result;
}

async function getPeliculasEntradasXFuncion() {
  var promise = await fetch("https://localhost:7215/api/Test/entradas_funcion");
  var result = await promise.json();
  return result;
}

async function getButacas() {
  var promise = await fetch("https://localhost:7215/api/Test/todas");
  var result = await promise.json();
  return result;
}

function getGenres(){

  const options = {
    method: 'GET',
    headers: {
      accept: 'application/json',
      Authorization: 'Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI1YmVmZjUxMzVhMjhlZDEwMzcyZWNiMDUxYTBkZDE2OSIsIm5iZiI6MTczMDIzODgwMS41NzQ5MTA5LCJzdWIiOiI2NzIxNTZmYzBjZDhhMmE1MDNhY2JmYzIiLCJzY29wZXMiOlsiYXBpX3JlYWQiXSwidmVyc2lvbiI6MX0.8JUzJNNxUGvDcn5f5YNNjDkYCUimkBpPOLU71O4x1YY'
    }
  };
  fetch('https://api.themoviedb.org/3/genre/movie/list?language=es', options)
    .then(res => res.json())
    .then(res => console.log(res))
    .catch(err => console.error(err));

}

async function renderSala() {
  const container = document.createElement('section');
  container.id = 'container';
  document.querySelector('main').appendChild(container);
  //const container = document.getElementById("container");
  const butacas = await getButacas();
  let rows = new Set();
  let columns = 1;
  butacas.forEach(butaca => {
    if(!rows.has(butaca.fila)) rows.add(butaca.fila);
    if(butaca.columna > columns) columns = butaca.columna;
  })
  const select = document.createElement("select");
  select.setAttribute("id", "select");
  select.addEventListener("change", () => paintDivs());
  const options = ["entradastotales", "frecuenciadeocupacion","frecuenciadeocupacionnormalizada", "frecuenciadeocupacionestandarizada" ]
  container.appendChild(select);
  options.forEach(option => {
    const optionElement = document.createElement("option");
    optionElement.value = option;
    optionElement.text = option;
    select.appendChild(optionElement);
  })
  rows.forEach(row => {
    const fila = document.createElement("div");
    fila.classList.add("row");
    container.appendChild(fila);
    for(let i = 1; i <= columns; i++) {
      const posicion = document.createElement("div");
      posicion.classList.add("posicion");
      posicion.setAttribute('data' , `${row}${i}`);
      posicion.innerText = `${row}${i}`;
      fila.appendChild(posicion);
    }
  })

}

async function paintDivs(){
  const data = await getResumen();
  const maxEstandar = Math.max(...data.map(posicion => posicion.frecuenciadeocupacionestandarizada));
  const myNodelist = document.querySelectorAll(".posicion");
  const option = document.getElementById("select").value;
  for (let i = 0; i < myNodelist.length; i++) {
    data.forEach(posicion => {
      if( posicion.posicion == myNodelist[i].getAttribute('data')){
        let color1 = "rgb(0,255,0,";
        let color2 = "rgb(0,255,0,";
        if(option == 'frecuenciadeocupacionestandarizada'){
          color2 = "rgb(255,0,0,";
        }
        if(posicion[option] > 0){
          myNodelist[i].style["background-color"] = `${color1}${posicion[option] * 1})`;
        }
        else{
          if(option == 'frecuenciadeocupacionestandarizada'){
            myNodelist[i].style["background-color"] = `${color2}${posicion[option]/maxEstandar * -1})`;
          }
          myNodelist[i].style["background-color"] = `${color2}${posicion[option] * -1})`;
        }
        
      } 
    })
  }
}

async function renderConsulta6(){
  const container = document.createElement('section');
  container.id = 'container';
  document.querySelector('main').appendChild(container);

  const select = document.createElement("select");
  select.setAttribute("id", "select");
  select.addEventListener("change", () => renderChart());
  const options = [ "entradas", "ent_x_func", "recaudacion"];
  options.forEach(option => {
    const optionElement = document.createElement("option");
    optionElement.value = option;
    optionElement.text = option;
    select.appendChild(optionElement);
  });
  container.appendChild(select);
  document.querySelector('main').appendChild(container);
}

async function renderChart(){
  const data = await getPeliculasEntradasXFuncion();
  const option = document.getElementById("select").value;


  const grafico = document.createElement('canvas');
  grafico.setAttribute('id', 'grafico');
  container.appendChild(grafico);
  const chart = new Chart(grafico, {
    type: 'bar',
    data: {
      labels: data.map(pelicula => pelicula.pelicula),
      datasets: [{
        label: `${option}`,
        data: data.map(pelicula => pelicula[option]),
        backgroundColor: [
          'rgba(255, 99, 132, 0.2)',
          'rgba(54, 162, 235, 0.2)',
          'rgba(255, 206, 86, 0.2)',
          'rgba(75, 192, 192, 0.2)',
          'rgba(153, 102, 255, 0.2)',
          'rgba(255, 159, 64, 0.2)'
        ]
      }]
    },
    options: {
      scales: {
        y: {
          beginAtZero: true
        }
      }
    }
  });
}

//fetch a la MVB si la usamos


function getCartelera(){
  const options = {
    method: 'GET',
    headers: {
      accept: 'application/json',
      Authorization: 'Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI1YmVmZjUxMzVhMjhlZDEwMzcyZWNiMDUxYTBkZDE2OSIsIm5iZiI6MTczMDIzODgwMS41NzQ5MTA5LCJzdWIiOiI2NzIxNTZmYzBjZDhhMmE1MDNhY2JmYzIiLCJzY29wZXMiOlsiYXBpX3JlYWQiXSwidmVyc2lvbiI6MX0.8JUzJNNxUGvDcn5f5YNNjDkYCUimkBpPOLU71O4x1YY'
    }
  };
  
  fetch('https://api.themoviedb.org/3/movie/now_playing?language=es-ES&page=1', options)
    .then(res => res.json())
    .then(res => res.results.map(movie => console.log(movie.title)))
    .catch(err => console.error(err));
  
}




//FIN TOMAS
