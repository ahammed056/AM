<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" indent="yes" encoding="utf-8"/>
  <!-- Find the root node called Menus then convert it to <UL> </UL> HTMLTags        and call MenuListing for its children -->
  <xsl:template match="/Menus">
    <ul>
      <xsl:attribute name="class">
        <xsl:text>menu</xsl:text>
      </xsl:attribute>
    
      <xsl:call-template name="MenuListing" />
    </ul>
  </xsl:template>
  <!-- Allow for recusive child node processing -->
  <xsl:template name="MenuListing">
    <xsl:apply-templates select="Menu" />
  </xsl:template>
  <xsl:template match="Menu">
    <li>
      <a>
        <!-- Convert Menu child elements to <li> <a> html tags  and attributes inside a tag -->
        <xsl:attribute name="href">
          <xsl:value-of select="MENULINK"/>
        </xsl:attribute>
        <xsl:value-of select="MENUNAME"/>
      </a>
      <!-- Recursively call MenuListing for child menu nodes -->
      <xsl:if test="count(Menu) > 0">
        <ul>
          <xsl:call-template name="MenuListing" />
        </ul>
      </xsl:if>
    </li>
  </xsl:template>
</xsl:stylesheet>
