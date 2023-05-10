using Data;
using Entities;
using Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesExtentios
    {
        public static IServiceCollection addServices(this IServiceCollection services)
        {
            //Inyeccion de dependencias de la Capa de negocio
            services.AddTransient<IServices<TbCliente>, ClienteService>();
            services.AddTransient<IServices<TbTipoCliente>, TipoClienteService>();
            services.AddTransient<IServices<TbFactura>, FacturaService>();
            services.AddTransient<IServices<TbDetalleFactura>, DetalleFacturaService>();
            services.AddTransient<IServices<TbTipoVentum>, TipoVentaService>();
            services.AddTransient<IServices<TbTipoPago>, TipoPagoService>();
            services.AddTransient<IServices<TbProducto>, ProductoService>();

            //inyeccion de dependencias de la Capa de datos
            services.AddTransient<IData<TbCliente>, ClienteData>();
            services.AddTransient<IData<TbTipoCliente>, TipoClienteData>();
            services.AddTransient<IData<TbFactura>, FacturaData>();
            services.AddTransient<IData<TbDetalleFactura>, DetalleFacturaData>();
            services.AddTransient<IData<TbTipoVentum>, TipoVentaData>();
            services.AddTransient<IData<TbTipoPago>, TipoPagoData>();
            services.AddTransient<IData<TbProducto>, ProductoData>();

            return services;
        }
    }
}

// Add services to the container.
/*Hace la inyeccion de dependencias de ClienteService;
 * Transient: Manejo dinamico de la memoria.
 * Scope: Mantiene la instancia en memoria mientras el usuario este logeado.
 * Singleton: Para que la intancia siempre este en memoria.
 */
