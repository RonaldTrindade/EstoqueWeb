// Adiciona uma classe de animação ao carregar a página
document.addEventListener("DOMContentLoaded", function () {
    const container = document.querySelector(".container-crud");
    if (container) {
        container.classList.add("fade-in");
    }
});

// Adiciona uma classe de animação ao clicar em links
document.querySelectorAll("a").forEach(link => {
    link.addEventListener("click", function (e) {
        e.preventDefault(); // Evita o comportamento padrão do link
        const href = this.getAttribute("href");

        // Adiciona uma classe de animação de saída
        const container = document.querySelector(".container-crud");
        if (container) {
            container.classList.add("fade-out");
        }

        // Aguarda a animação terminar antes de redirecionar
        setTimeout(() => {
            window.location.href = href;
        }, 500); // Tempo da animação em milissegundos
    });
});